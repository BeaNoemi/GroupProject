using UnityEngine;
using System.Collections;

public class ChargerAI : Enemy{
    public int chargeSpeed = 13;
    public float cooldownTime = 3;
    public float cooldownTimer = 0;
    public bool isCharging;

    void Start(){
        InitEntity("Charger", player, 100, 3, 10, 40, 1.5f);
        cooldownTimer = cooldownTime;
    }

	void FixedUpdate(){
        Attack();
        if(!isAttacking){
            if(cooldownTimer <= 0){
                isCharging = true;
                myTransform.position += myTransform.forward * chargeSpeed * Time.deltaTime;
            }else{
                myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
                cooldownTimer -= Time.deltaTime;
            }
        }else{
            cooldownTimer = cooldownTime;
            isCharging = false;
        }
	}

    void OnTriggerEnter(Collider collider){
        if(collider.transform.tag != "Floor"){
            if(isCharging) cooldownTimer = cooldownTime;
            isCharging = false;
        }
    }
}
