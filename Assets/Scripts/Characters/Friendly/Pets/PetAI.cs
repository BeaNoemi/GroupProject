using UnityEngine;
using System.Collections;

public class PetAI : MonoBehaviour {
	public Transform PetTargetTranform;
	public int moveSpeed;
	public int roationSpeed;
	public int maxDistance; 
	private string PetState; //This tells the pet to attack or not (Passive/Defensive/Aggressive/Shop)
	private Transform myTransform;
	public GameObject PetTarget;
	public bool AttackingEnemy;
	
	void Awake(){
		PetState = "Aggressive";
		myTransform=transform;
		AttackingEnemy = false;
		
	}
	
	// Use this for initialization
	void Start () {
	
		PetTarget = GameObject.FindGameObjectWithTag("Enemy");
		
		
		
	}
	
	// Update is called once per frame
	
	
	void Update () {
		
		PetTargeting();
		PetTargetTranform =	PetTarget.transform;
					
		
			Debug.DrawLine (PetTargetTranform.position,myTransform.position,Color.yellow);
	
			//look	at target
			
			myTransform.rotation=Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(PetTargetTranform.position - myTransform.position ),roationSpeed * Time.deltaTime );
		
		
			if(Vector3.Distance (PetTargetTranform.position, myTransform.position )> maxDistance){
			//Move to target
	
				myTransform.position +=  myTransform.forward * moveSpeed *Time.deltaTime;
		
		}
	}
	
	
	void PetTargeting(){  //this tells the pet what to target depending on the state set by the player
		GameObject TempPetTarget; 
		Transform tempPetTargetTranform;		
		TempPetTarget = PetTarget;
		tempPetTargetTranform = PetTargetTranform;
		PetTargetTranform = null;
		PetTarget = null;
		
		
		switch(PetState){
			
			case "Passive": //Targets the player and follows
				PetTarget = GameObject.FindGameObjectWithTag("Player"); 
				AttackingEnemy = false;
				Debug.Log ("Passive");
			break;
			
			case "Defensive": //Targets the player until the player attacks
				PetTarget = GameObject.FindGameObjectWithTag("Player");
				AttackingEnemy = false;
				Debug.Log ("Defensive");
			break;
			
			case "Aggressive"://Targets enemys 
			
			
				if(TempPetTarget == null){ //If current target is nothing find an enemy
					PetTarget = GameObject.FindGameObjectWithTag("Enemy"); 			
				
				}else if(TempPetTarget.tag != "Enemy"){//if the curent target is not an enemy make it one
						
					PetTarget = GameObject.FindGameObjectWithTag("Enemy"); 
				
				}else{
					
					PetTarget= TempPetTarget; //keeps the target the same if enemy already targeted
					
				}
			
				if(PetTarget== null ){ //if the target is still empty follow the player
				
					PetTarget = GameObject.FindGameObjectWithTag("Player"); 		
					AttackingEnemy = false;
				}else{
				
					AttackingEnemy = true;	
				}
			
			
			
				Debug.Log ("Aggressive");
			break;
			
			
			case "Shop"://Pet is in the shop so no target
				Debug.Log ("Shop");
			break;
					
			
	}
		
		
		
		
	}	
	
	
	
	
}


	
	
	

