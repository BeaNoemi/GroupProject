using UnityEngine;
using System.Collections;

public class CastingSpells : MonoBehaviour {

    private float timeDelay = 0.0f;

    public Rigidbody fireballObject;
    public Transform spawnPos;
    public float delayAmount = 2.0f;
    public float damage = 10f;
    

	void Update(){
        if(Input.GetMouseButtonDown(0)){
            Rigidbody newFireballObject = Instantiate(fireballObject, spawnPos.position, spawnPos.rotation) as Rigidbody;
            newFireballObject.name = "fireball";
            newFireballObject.AddForce(transform.forward * 4000.0f);
            Destroy(newFireballObject.gameObject, 2.5f);
        }
	}
}
