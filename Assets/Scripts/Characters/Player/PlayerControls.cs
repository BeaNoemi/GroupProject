using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControls : Entity{

    private Camera mCamera;

    public enum PlayerState{
        Idle,
        Moving,
    };

    public enum AttackState{
        None,
        AttackingStill,
        AttackingMoving
    };

    public enum PlayerAnimState{
        Idle,
        Forward,
        Back,
        Left,
        Right,
        ForwardDiagonalRight,
        ForwardDiagonalLeft,
        BackDiagonalRight,
        BackDiagonalLeft,
        AttackingStill,
        AttackingMoving
    };

    //Player Controls
    public PlayerState playerState = PlayerState.Idle;
    public AttackState attackState = AttackState.None;
    public PlayerAnimState playerAnimState = PlayerAnimState.Idle;
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
        InitEntity("Player", null, 100, 100, 9, 4, 5, 15, 1.5f, 0, 1);

        mCamera = Camera.mainCamera;

        delayToFire = delayBetweenFiring;
	}

	void Update(){
        InputHandeling();
        AttackEnemy();

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
            playerState = PlayerState.Moving;
        }

<<<<<<< HEAD
        //Set player state for animations
=======
>>>>>>> ee77e8f054f1f80a7a243e3b2bd93ae770926987
        if(inputX == 0 && inputY == 0){
            playerAnimState = PlayerAnimState.Idle;
        }else if(inputX < 0 && inputY == 0){
            playerAnimState = PlayerAnimState.Left;
        }else if(inputX > 0 && inputY == 0){
            playerAnimState = PlayerAnimState.Right;
        }else if(inputX == 0 && inputY > 0){
            playerAnimState = PlayerAnimState.Forward;
        }else if(inputX == 0 && inputY < 0){
            playerAnimState = PlayerAnimState.Back;
        }else if(inputX < 0 && inputY < 0){
            playerAnimState = PlayerAnimState.BackDiagonalLeft;
        }else if(inputX > 0 && inputY < 0){
            playerAnimState = PlayerAnimState.BackDiagonalRight;
        }else if(inputX < 0 && inputY > 0){
            playerAnimState = PlayerAnimState.ForwardDiagonalLeft;
        }else if(inputX > 0 && inputY > 0){
            playerAnimState = PlayerAnimState.ForwardDiagonalRight;
        }

<<<<<<< HEAD
        //Camera control
        RotationX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        RotationY -= Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;
        RotationY = Mathf.Clamp(RotationY, minimumY, maximumY);

        //Set player state
=======
        RotationX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        RotationY -= Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;
        RotationY = Mathf.Clamp(RotationY, minimumY, maximumY);
>>>>>>> ee77e8f054f1f80a7a243e3b2bd93ae770926987
        switch(playerState){
            case PlayerState.Idle:
                mCamera.transform.position = new Vector3(mCamera.transform.position.x, RotationY, mCamera.transform.position.z);
                mCamera.transform.RotateAround(myTransform.position, Vector3.up, RotationX);
                mCamera.transform.LookAt(myTransform);
                break;
            case PlayerState.Moving:
                myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;

                mCamera.transform.position = new Vector3(mCamera.transform.position.x, RotationY, mCamera.transform.position.z);
                myTransform.Rotate(Vector3.up, RotationX);
                mCamera.transform.LookAt(myTransform);
                break;
        }

<<<<<<< HEAD
        //Set player animation
=======
>>>>>>> ee77e8f054f1f80a7a243e3b2bd93ae770926987
        switch(playerAnimState){
            case PlayerAnimState.Idle:

                break;
            case PlayerAnimState.Forward:
                mCamera.transform.parent = null;
                myTransform.rotation = Quaternion.Euler(myTransform.rotation.x, mCamera.transform.localEulerAngles.y, myTransform.rotation.z);
                mCamera.transform.parent = myTransform;
                break;
            case PlayerAnimState.Back:
                mCamera.transform.parent = null;
                myTransform.rotation = Quaternion.Euler(myTransform.rotation.x, mCamera.transform.localEulerAngles.y - 180, myTransform.rotation.z);
                mCamera.transform.parent = myTransform;
                break;
            case PlayerAnimState.Left:
                mCamera.transform.parent = null;
                myTransform.rotation = Quaternion.Euler(myTransform.rotation.x, mCamera.transform.localEulerAngles.y - 90, myTransform.rotation.z);
                mCamera.transform.parent = myTransform;
                break;

            case PlayerAnimState.Right:
                mCamera.transform.parent = null;
                myTransform.rotation = Quaternion.Euler(myTransform.rotation.x, mCamera.transform.localEulerAngles.y + 90, myTransform.rotation.z);
                mCamera.transform.parent = myTransform;
                break;

            case PlayerAnimState.ForwardDiagonalLeft:
                mCamera.transform.parent = null;
                myTransform.rotation = Quaternion.Euler(myTransform.rotation.x, mCamera.transform.localEulerAngles.y - 45, myTransform.rotation.z);
                mCamera.transform.parent = myTransform;
                break;
            case PlayerAnimState.ForwardDiagonalRight:
                mCamera.transform.parent = null;
                myTransform.rotation = Quaternion.Euler(myTransform.rotation.x, mCamera.transform.localEulerAngles.y + 45, myTransform.rotation.z);
                mCamera.transform.parent = myTransform;
                break;
            case PlayerAnimState.BackDiagonalLeft:
                mCamera.transform.parent = null;
                myTransform.rotation = Quaternion.Euler(myTransform.rotation.x, mCamera.transform.localEulerAngles.y - (180 - 45), myTransform.rotation.z);
                mCamera.transform.parent = myTransform;
                break;
            case PlayerAnimState.BackDiagonalRight:
                mCamera.transform.parent = null;
                myTransform.rotation = Quaternion.Euler(myTransform.rotation.x, mCamera.transform.localEulerAngles.y + (180 - 45), myTransform.rotation.z);
                mCamera.transform.parent = myTransform;
                break;
            case PlayerAnimState.AttackingStill:

                break;
            case PlayerAnimState.AttackingMoving:

                break;
        }
    }

    public void AttackEnemy(){
        if(health == 0){
            mCamera.transform.parent = null;
            target = null;
            player = null;
            Destroy(gameObject);
        }

        RaycastHit hit;
        isAttacking = false;
        Vector3 forward = myTransform.TransformDirection(Vector3.forward);
        Debug.DrawRay(myTransform.position, forward * attackDistance, Color.green);

        if(Physics.Raycast(myTransform.position, forward, out hit, attackDistance)){
            if(hit.transform.tag == "Enemy"){
                isAttacking = true;
                playerEnemy = hit.transform;
            }
        }else{
            playerEnemy = null;
        }

        if(isAttacking){
            if(Input.GetMouseButton(0)){
                if(attackTime < coolDownTime){
                    attackTime += Time.deltaTime;
                }else if(attackTime > coolDownTime){
                    attackTime = 0.0f;

                    switch(playerState){
                        case PlayerState.Idle:
                            attackState = AttackState.AttackingStill;
                            break;
                        case PlayerState.Moving:
                            attackState = AttackState.AttackingMoving;
                            break;
                    }
                    Enemy enemy = (Enemy)playerEnemy.GetComponent(typeof(Enemy));
                    Debug.Log(enemy.health);
			        enemy.AdjustHealth(strength);
                }
            }
        }
    }
}