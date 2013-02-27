using UnityEngine;
using System.Collections;

public class ImpLeaderAI : Enemy{

    public int jumpHeight = 3;
    public int sideJumpDist = 3;

	void Start(){
        InitEntity("Imp", player, 100,100,0,0, 8, 0, 10, 20, 1.5f, 10, 1);
    }
	
	void FixedUpdate(){
        Attack();
        if(!isAttacking){
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
            
        }
        myTransform.LookAt(target);
	}

    float CalculateJumpVerticalSpeed(){
	    return Mathf.Sqrt(2 * jumpHeight * gravity);
	}
}