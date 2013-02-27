using UnityEngine;
using System.Collections;

public class FlyingMob : Enemy{

    public float swoopDistance = 6;
    public float swoopSpeed = 26;
    public float swoopTime = 6;
    public float flyDistance = 3;
    public float cooldownTimer = 0;
    public bool isSwooping = false;

    public Vector3 swoopPos = Vector3.zero;

	void Start(){
        InitEntity("Flying Mob", player, 100,100,0,0, 10, 10, 7, 16, 1f, 10, 1);
        cooldownTimer = swoopTime;
    }
	
	void FixedUpdate() {
	    Attack();
        myTransform.LookAt(target);
        if(cooldownTimer <= 0 && target){
            if(!isSwooping){
                if(Vector3.Distance(myTransform.position, target.position) <= swoopDistance){
                    swoopPos = myTransform.position;
                    isSwooping = true;
                }
            }else{
                myTransform.position += myTransform.forward * swoopSpeed * Time.deltaTime;
            }
        }else{
            if(Vector3.Distance(myTransform.position, target.position) >= flyDistance){
                myTransform.position = new Vector3(myTransform.position.x, 3f, myTransform.position.z);
                myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
            }
            cooldownTimer -= Time.deltaTime;
        }

        if(isAttacking){
            isSwooping = false;
            cooldownTimer = swoopTime;
        }
	}
}
