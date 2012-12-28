using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGeneration : MonoBehaviour{

    public List<Transform> Walls;

	void Start(){
	    Debug.Log(Walls[0].collider.bounds.size);

        for(int i = 0; i < 4; i ++){
            //GameObject wall = Instantiate(Walls[0], Vector3.zero, Quaternion.identity) as GameObject;
            //wall.transform.rotation = new Quaternion(-90, 0, 0, 0);
        }

	}

	void Update(){
	
	}
}
