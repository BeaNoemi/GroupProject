using UnityEngine;
using System.Collections;

public class ImpAI : Enemy{
    ImpLeaderAI impLeaderAi;

    public Transform impLeader = null;
    
    public int jumpHeight = 3;
    public int sideJumpDist = 3;

	void Start(){
        impLeader = GameObject.Find("ImpLeader").transform;
        impLeaderAi = impLeader.GetComponent<ImpLeaderAI>();
<<<<<<< HEAD
        InitEntity("Imp", impLeader, 100,100, 6, 0, 3, 10, 1.5f, 10, 1);
=======
        InitEntity("Imp", impLeader, 100,100,0,0,6, 0, 3, 10, 1.5f, 10, 1);
>>>>>>> github work or i kill you
    }
	
	void FixedUpdate(){
        Attack();
        CheckGrounded();
        if(!impLeaderAi.isAttacking){
            target = impLeader;
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
            if(sideJumpDist == Mathf.Abs(sideJumpDist) * (-1)) sideJumpDist = Mathf.Abs(sideJumpDist); else sideJumpDist = Mathf.Abs(sideJumpDist) * (-1);

            if(isGrounded){
                Vector3 velocity = rigidbody.velocity;
                rigidbody.velocity = new Vector3(sideJumpDist, CalculateJumpVerticalSpeed(), velocity.z);
            }
        }else{
            target = player;
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
            if(sideJumpDist == Mathf.Abs(sideJumpDist) * (-1)) sideJumpDist = Mathf.Abs(sideJumpDist); else sideJumpDist = Mathf.Abs(sideJumpDist) * (-1);

            if(isGrounded){
                Vector3 velocity = rigidbody.velocity;
                rigidbody.velocity = new Vector3(sideJumpDist, CalculateJumpVerticalSpeed(), velocity.z);
            }
        }
        myTransform.LookAt(target);
	}

    float CalculateJumpVerticalSpeed(){
	    return Mathf.Sqrt(2 * jumpHeight * gravity);
	}
}