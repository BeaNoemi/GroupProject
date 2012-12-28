using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControls : Entity{

    private Quaternion OriginalRotation;

    public Rigidbody rbTarget = null;
    public float dodgeAmount = 300f;

    public List<GameObject> SpellPrefabs;
    public float delayBetweenFiring = 0.5f;
    public float delayToFire;

	void Start(){
        InitEntity("Player", null, 100, 9, 4, 7, 1.5f);
		rbTarget = GetComponent<Rigidbody>();
		rbTarget.freezeRotation = true;

        delayToFire = delayBetweenFiring;
        OriginalRotation = transform.localRotation;

	}

    void Update(){
        delayToFire -= Time.deltaTime;
    }

    private float RotationX = 0f;
    public float sensitivityX = 300f;

    public bool isGameplay;
	void FixedUpdate(){
        InputHandeling();

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

		Vector3 targetVelocity = new Vector3(0, 0, inputY);
	    targetVelocity = transform.TransformDirection(targetVelocity);
	    targetVelocity *= moveSpeed;

        myTransform.position += targetVelocity * Time.deltaTime;

        RotationX = inputX * sensitivityX * Time.deltaTime;
        Vector3 targetRotation = new Vector3(0, RotationX, 0);
	    myTransform.Rotate(targetRotation);

	}

    void InputHandeling(){
        //Key Input
        if(Input.GetKeyDown(KeyCode.Q)){
            rigidbody.AddForce(Vector3.left * dodgeAmount * Time.deltaTime, ForceMode.Impulse);
        }else if(Input.GetKeyDown(KeyCode.E)){
            rigidbody.AddForce(Vector3.right * dodgeAmount * Time.deltaTime, ForceMode.Impulse);
        }
    }
}