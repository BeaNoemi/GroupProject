using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour{

    public Transform myTransform = null;
    public static Transform player = null;
	public Transform enemy = null;
    public Transform playerEnemy = null;
    public bool isAttacking = false;
    public bool isGrounded = false;
    
    public float gravity = 140.0f;

    //Entity variables
    public string mobName = null;
    public Transform target = null;
	public int health = 0;
    public int moveSpeed = 0;
    public int rotationSpeed = 0;
    public int strength = 0;
	public int maxHealth = 100;
    public float attackDistance = 0.0f;
    public float viewDistance = 0.0f;
    public float coolDownTime = 0.0f;

    public float attackTime = 0.0f;

<<<<<<< HEAD
<<<<<<< HEAD
    //When called the entity variables are set
=======
>>>>>>> ee77e8f054f1f80a7a243e3b2bd93ae770926987
=======
>>>>>>> ee77e8f054f1f80a7a243e3b2bd93ae770926987
    public void InitEntity(string name, Transform targ, int hp, int maxhp, int ms, int rs, int minstr, int maxStr, float ad, float vd, float cdt){
        mobName = name;
        target = targ;
        health = hp;
		maxHealth = maxhp;
        moveSpeed = ms;
        rotationSpeed = rs;
        strength = Random.Range(minstr, maxStr);
        attackDistance = ad;
        viewDistance = vd;
        coolDownTime = cdt;
    }

    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
        myTransform = transform;
    }

    void Update(){
<<<<<<< HEAD
        //Entity is destroyed when health is equal or less than 0
        if(health <= 0){
=======
        if(health == 0){
<<<<<<< HEAD
>>>>>>> ee77e8f054f1f80a7a243e3b2bd93ae770926987
=======
>>>>>>> ee77e8f054f1f80a7a243e3b2bd93ae770926987
            Debug.Log("Dead");
            Destroy(gameObject);
        }
    }

    void FixedUpdate(){
<<<<<<< HEAD
<<<<<<< HEAD
        //Add gravity
=======
>>>>>>> ee77e8f054f1f80a7a243e3b2bd93ae770926987
=======
>>>>>>> ee77e8f054f1f80a7a243e3b2bd93ae770926987
        rigidbody.AddForce(new Vector3 (0, -gravity * rigidbody.mass, 0));
    }

    public void CheckGrounded(){
        RaycastHit hit;
        isGrounded = false;
        Vector3 down = myTransform.TransformDirection(Vector3.down);
        Debug.DrawRay(myTransform.position, down * 1.8f, Color.magenta);

        if(Physics.Raycast(myTransform.position, down, out hit, 1.8f)){
            if(hit.transform.tag == "Floor"){
                isGrounded = true;
            }
        }
    }

	public void AdjustHealth(int adj){
		health -= adj;
		
		if(health<0){
			health=0;
		} 
		if (health > maxHealth){
		    health = maxHealth;
		}
	}
}
