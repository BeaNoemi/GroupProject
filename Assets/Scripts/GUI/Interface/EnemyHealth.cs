using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public Enemy EnemyControls;
	public Transform target; 

	public Texture2D background = null;
	
	public Texture2D healthbar = null;
	
	private bool draw=true;
	
	// Use this for initialization
	void Init() {
			EnemyControls = (Enemy)playerEnemy.GetComponent(typeof(Enemy));
	}
	// Update is called once per frame
	void Update () {
	  var wantedPos = Camera.main.WorldToViewportPoint (target.position); 
     	transform.position = wantedPos; 
	}
	void OnDrawGUI(){
 		if (!draw) return;
		
	}
	void OnBecameVisible () {
 		draw= true;
	}
	void OnBecameInvisible () {
 		draw= false;
	}
}