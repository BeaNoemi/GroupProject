using UnityEngine;
using System.Collections;

public class ChargerAI : Enemy{
    public int chargeSpeed = 13;
    public float cooldownChargeTime = 3;
    public float cooldownChargeTimer = 0;
    public bool isCharging;

    void Start(){
        InitEntity("Charger", player, 100, 100, 100, 100, 3, 10, 15, 25, 1.5f, 10, 2);
        cooldownChargeTimer = cooldownChargeTime;
    }

	void FixedUpdate(){
        Attack();
        if(!isAttacking && target){
            if(cooldownChargeTimer <= 0){
                isCharging = true;
                myTransform.position += myTransform.forward * chargeSpeed * Time.deltaTime;
            }else{
                myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
                cooldownChargeTimer -= Time.deltaTime;
            }
        }else{
            cooldownChargeTimer = cooldownChargeTime;
            isCharging = false;
        }
	}

    void OnTriggerEnter(Collider collider){
        if(collider.transform.tag != "Floor"){
            if(isCharging) cooldownChargeTimer = cooldownChargeTime;
            isCharging = false;
        }
    }
}
