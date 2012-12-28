using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour{

    CastingSpells castSpells;

    public PlayerControls charControls;

    public Transform myTransform = null;
    public Transform player = null;

    public bool isAttacking = false;
    public bool isGrounded = false;
    
    public float gravity = 140.0f;

    public string mobName = null;
    public Transform target = null;
    public int health = 0;
    public int moveSpeed = 0;
    public int rotationSpeed = 0;
    public int strength = 0;
    public float attackDistance = 0.0f;
    

    public void InitEntity(string name, Transform targ, int h, int ms, int rs, int str, float ad){
        mobName = name;
        target = targ;
        health = h;
        moveSpeed = ms;
        rotationSpeed = rs;
        strength = str;
        attackDistance = ad;
    }
    
    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
        castSpells = player.GetComponent<CastingSpells>();
        myTransform = transform;
        charControls = player.GetComponent<PlayerControls>();
    }

    void Update(){
        if(health <= 0){
            Destroy(gameObject);
        }
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

    public void Attack(){
        RaycastHit hit;
        isAttacking = false;
        Vector3 forward = myTransform.TransformDirection(Vector3.forward);
        Debug.DrawRay(myTransform.position, forward * attackDistance, Color.green);

        if(Physics.Raycast(myTransform.position, forward, out hit, attackDistance)){
            if(hit.transform.tag == "Player"){
                isAttacking = true;
            }
        }
    }
}
