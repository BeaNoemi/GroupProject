using UnityEngine;
using System.Collections;

public class CustomCursor : MonoBehaviour {

    public bool paused;

    void Awake(){
        Time.timeScale = 1;
    }

    void Update(){
        if(!paused)Screen.lockCursor = true;
        else Screen.lockCursor = false;
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!paused){
                paused = true;
                Time.timeScale = 0;
            }else{
                paused = false;
                Time.timeScale = 1;
            }
        }
    }

    void OnGUI(){
        if(paused){
            if(GUILayout.Button("Main menu")){
                Screen.lockCursor = false;
                Application.LoadLevel(0);
            }
        }
    }
}
