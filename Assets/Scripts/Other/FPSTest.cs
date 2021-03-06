using UnityEngine;
using System.Collections;

public class FPSTest : MonoBehaviour {

    public GameObject imp;
    public int amount;


    float mainSpeed = 100.0f;
    float shiftAdd = 250.0f;
    float maxShift = 1000.0f;
    float camSens = 0.25f;
    Vector3 lastMouse = new Vector3(255, 255, 255);
    float totalRun = 1.0f;
	
	void Update(){
	    if(Input.GetKey(KeyCode.Space)){
            Instantiate(imp, new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100)), Quaternion.identity);
            amount++;
        }

        lastMouse = Input.mousePosition - lastMouse ; 
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0 ); 
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x , transform.eulerAngles.y + lastMouse.y, 0); 
        transform.eulerAngles = lastMouse;
        lastMouse =  Input.mousePosition;

        var p = GetBaseInput(); 

        if (Input.GetKey (KeyCode.LeftShift)){ 
            totalRun += Time.deltaTime; 
            p  = p * totalRun * shiftAdd; 
            p.x = Mathf.Clamp(p.x, -maxShift, maxShift); 
            p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
            p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
        }else{
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1, 1000); 
            p = p * mainSpeed;
        }

        p = p * Time.deltaTime;
        transform.Translate(p);
	}

    void OnGUI(){
        GUILayout.Label("FPS: " + 1/Time.deltaTime);
        GUILayout.Label("Amount: " + amount);
    }

    private Vector3 GetBaseInput(){
        Vector3 p_Velocity = new Vector3();

        if(Input.GetKey(KeyCode.W)){
            p_Velocity += new Vector3(0, 0 , 1);
        }

        if (Input.GetKey (KeyCode.S)){
            p_Velocity += new Vector3(0, 0 , -1);
        }

        if (Input.GetKey (KeyCode.A)){
            p_Velocity += new Vector3(-1, 0 , 0);
        }

        if (Input.GetKey (KeyCode.D)){
            p_Velocity += new Vector3(1, 0 , 0);
        }

        return p_Velocity;
    }
}
