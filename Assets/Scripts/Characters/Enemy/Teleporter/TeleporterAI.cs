using UnityEngine;
using System.Collections;

public class TeleporterAI : Enemy{

    public float maxX = 4;
    public float maxZ = 4;

    public int teleportMaxTime = 5;
    public int teleportTime = 0;
    public float cooldownTimer = 0;

	void Start(){
        InitEntity("Teleporter", player, 100,100, 10, 10, 15, 25, 1.5f, 10, 2);
        teleportTime = Random.Range(1, teleportMaxTime);
        cooldownTimer = teleportTime;
    }

	void FixedUpdate(){
	    Attack();

        if(cooldownTimer <= 0 && target){
            Vector3 newPos = new Vector3(Random.Range(target.position.x - maxX, target.position.x + maxX), myTransform.position.y, Random.Range(target.position.z - maxZ, target.position.z + maxZ));
            myTransform.position = newPos;
            teleportTime = Random.Range(1, teleportMaxTime);
            cooldownTimer = teleportTime;
        }else{
            cooldownTimer -= Time.deltaTime;
        }
        myTransform.LookAt(target);
	}
}
