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
		
			Debug.Log (direction );
		
			if(distance<2.5f){
				if(direction>0){
			
					Entity  eh2 = (Entity)testtarget.GetComponent("ChargerAI");
					eh2.AdjustHealth(-10);
					
				}
			}
		}
	}
	
}
