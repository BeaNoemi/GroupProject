using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControls : Entity{

    private Camera mCamera;


    public enum PlayerState{
        Idle,
        Walking
    };

    //Player Controls
    public PlayerState playerState = PlayerState.Idle;
    public float dodgeAmount = 300f;

    //Camera Controls
    public float RotationX = 0f;
    private float RotationY = 0f;

    public float sensitivityX = 200f;
	public float sensitivityY = 20f;
	public float minimumY = 0f;
	public float maximumY = 10f;

    //Spells
    public List<GameObject> SpellPrefabs;
    public float delayBetweenFiring = 0.5f;
    public float delayToFire;

	void Start(){
        InitEntity("Player", null, 100,100, 9, 4, 7, 1.5f);

        mCamera = Camera.mainCamera;

        delayToFire = delayBetweenFiring;
	}

	void Update(){
        InputHandeling();

        //Spells
        delayToFire -= Time.deltaTime;
	}

    void InputHandeling(){
        //Key Input
        if(Input.GetKeyDown(KeyCode.Q)){
            rigidbody.AddForce(Vector3.left * dodgeAmount * Time.deltaTime, ForceMode.Impulse);
        }else if(Input.GetKeyDown(KeyCode.E)){
            rigidbody.AddForce(Vector3.right * dodgeAmount * Time.deltaTime, ForceMode.Impulse);
        }

        //Controls
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if(inputX == 0 && inputY == 0){
            playerState = PlayerState.Idle;
        }else{
            playerState = PlayerState.Walking;
        }

        RotationX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        RotationY -= Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;
        RotationY = Mathf.Clamp(RotationY, minimumY, maximumY);
        switch(playerState){
            case PlayerState.Idle:
                mCamera.transform.position = new Vector3(mCamera.transform.position.x, RotationY, mCamera.transform.position.z);
                mCamera.transform.RotateAround(myTransform.position, Vector3.up, RotationX);
                mCamera.transform.LookAt(myTransform);
                break;
            case PlayerState.Walking:
                mCamera.transform.parent = null;
                myTransform.rotation = Quaternion.Euler(myTransform.rotation.x, mCamera.transform.localEulerAngles.y, myTransform.rotation.z );
                mCamera.transform.parent = myTransform;

                Vector3 targetVelocity = new Vector3(inputX, 0, inputY);
	            targetVelocity = transform.TransformDirection(targetVelocity);
	            targetVelocity *= moveSpeed;

                myTransform.position += targetVelocity * Time.deltaTime;

                mCamera.transform.position = new Vector3(mCamera.transform.position.x, RotationY, mCamera.transform.position.z);
                myTransform.Rotate(Vector3.up, RotationX);
                mCamera.transform.LookAt(myTransform);
                break;
        }
    }
}