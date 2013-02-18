using UnityEngine;
using System.Collections;

public class TankAI : Enemy{

	void Start(){
<<<<<<< HEAD
        InitEntity("Tank", player, 100,100, 10, 10, 20, 40, 1.5f, 10, 2);
=======
        InitEntity("Tank", player, 100,100,0,0, 10, 10, 20, 40, 1.5f, 10, 2);
>>>>>>> github work or i kill you
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
