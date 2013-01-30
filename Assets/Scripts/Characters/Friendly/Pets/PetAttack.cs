using UnityEngine;
using System.Collections;

public class PetAttack : MonoBehaviour {

	public GameObject testtarget;
	public float attackTimer;
	public float cooldown;
	//public GameObject Self;
	
	// Use this for initialization
	void Start () {
		attackTimer = 0;
		cooldown = 2.0f;
		
		
			
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
			if (attackTimer >0){
			attackTimer -= Time.deltaTime;
			}
		
			if (attackTimer<0){
			attackTimer=0;
			}
			if(attackTimer ==0){
			Attack();
			attackTimer = cooldown;
			
			
		}
		
						
	}
	
	
	
	private void Attack(){
		
		GameObject selfTarget = GameObject.FindGameObjectWithTag("Pet");
		PetAI eh1= (PetAI)selfTarget.GetComponent("PetAI");
		testtarget = eh1.go;
		if(testtarget != null) {
			float distance=Vector3.Distance (testtarget.transform.position, transform.position );
	
			Vector3 dir = (testtarget.transform.position - transform.position).normalized;
			
			float direction = Vector3.Dot (dir,transform.forward );
		
			
			
			if(distance<2.5f){
				if(direction>0){
										
					Enemy eh2 = (Enemy)testtarget.GetComponent ("Enemy");
						eh2.AdjustHealth (10);
					
					
					/*
			  		switch (testtarget.name){

						case "Charger":
							Entity  eh2 = (Entity)testtarget.GetComponent("Enemy");
							eh2.AdjustHealth(-10);
						 	Debug.Log("1"); 
							break;
						case "Flying":
						Debug.Log("2"); 
							break;

						case "Imp": 
						Debug.Log("3"); 
							break;
						case "ImpLeader": 
						Debug.Log("4"); 
							break;
						case "Teleporter": 
						Debug.Log("5"); 
							break;

					}	*/												
				}
			}
		}
	}
	
}
