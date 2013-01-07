using UnityEngine;
using System.Collections;

public class TankAI : Entity{

	void Start(){
        InitEntity("Tank", player, 100, 10, 10, 40, 1.5f);
    }

	void FixedUpdate() {
	    Attack();
        if(!isAttacking){
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
            myTransform.position = new Vector3(myTransform.position.x, 2.5f, myTransform.position.z);
        }
        myTransform.LookAt(target);
	}
}