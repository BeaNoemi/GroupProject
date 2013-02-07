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
		
		GameObject selfTarget = GameObject.FindGameObjectWithTag("Pet");
		PetAI eh1= (PetAI)selfTarget.GetComponent("PetAI");
		testtarget = eh1.PetTarget;
		
		if (testtarget != null){
			
			
			if (testtarget.tag != "Player" & CanAttack()){
				
				Attack();
			}
				
		}	
		
		
		
						
	}
	
		
	private void Attack(){
		float distance=Vector3.Distance (testtarget.transform.position, transform.position );
	
		Vector3 dir = (testtarget.transform.position - transform.position).normalized;
			
		float direction = Vector3.Dot (dir,transform.forward );
		
		GameObject selfTarget = GameObject.FindGameObjectWithTag("Pet");
		PetAI eh1= (PetAI)selfTarget.GetComponent("PetAI");
		testtarget = eh1.PetTarget;
					
		if(distance<2.5f){
			if(direction>0){
										
				Enemy eh2 = (Enemy)testtarget.GetComponent ("Enemy");
				eh2.AdjustHealth (2);
				attackTimer = cooldown;
																
			}
		}
	}
	
	
	private void Follow(){
		
		float distance=Vector3.Distance (testtarget.transform.position, transform.position );
	
		Vector3 dir = (testtarget.transform.position - transform.position).normalized;
			
		float direction = Vector3.Dot (dir,transform.forward );
		
		
		
	}	
	
	private bool CanAttack(){
		
		if (attackTimer >0){
			attackTimer -= Time.deltaTime;			
		}
		
		if (attackTimer<0){
			attackTimer=0;			
		}
		if(attackTimer ==0){
			return true;
				
		}
		return false;
		
	}
	
	
	
	
	
	
}
