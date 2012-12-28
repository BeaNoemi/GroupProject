using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

    void OnCollisionEnter(Collision collision){
        if(collision.transform.parent.GetType() == typeof(Entity)){
            Debug.Log("Hit");
        }
    }
}
