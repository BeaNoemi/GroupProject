using UnityEngine;
using System.Collections;

public class Enemy : Entity{

	void Start(){
        
		target = player;
    
	}
	
	public void Attack(){
        RaycastHit hit;
        isAttacking = false;
        Vector3 forward = myTransform.TransformDirection(Vector3.forward);
        Debug.DrawRay(myTransform.position, forward * attackDistance, Color.green);

        if(Physics.Raycast(myTransform.position, forward, out hit, attackDistance)){
            if(hit.transform.tag == "Player"){
                isAttacking = true;
            }

            if(myTransform.tag == "Player"){
                playerEnemy = hit.transform;
            }
        }
    }

}
