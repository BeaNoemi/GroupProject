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
	public int mana = 0;
    public int moveSpeed = 0;
    public int rotationSpeed = 0;
    public int strength = 0;
	public int maxHealth = 100;
	public int maxMana = 100;
    public float attackDistance = 0.0f;
    public float viewDistance = 0.0f;
    public float coolDownTime = 0.0f;

    public float attackTime = 0.0f;

    //When called the entity variables are set
    public void InitEntity(string name, Transform targ, int hp, int maxhp,int mp, int maxmp, int ms, int rs, int minstr, int maxStr, float ad, float vd, float cdt){
        mobName = name;
        target = targ;
        health = hp;
		maxHealth = maxhp;
		mana = mp;
		maxMana = maxmp;
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
        //Entity is destroyed when health is equal or less than 0
        if(health == 0){
            Debug.Log("Dead");
            Destroy(gameObject);
        }
    }

    void FixedUpdate(){
        //Add gravity
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
	
	public void AdjustMana (int adj){
		mana -= adj;
		
		if(mana<0){
			mana=0;
		}
		if (mana > maxMana){
			mana = maxMana;
		}
	}
}
