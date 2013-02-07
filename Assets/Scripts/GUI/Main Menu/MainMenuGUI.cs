using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour{
    void Start(){
        Screen.showCursor = true;
    }

    void OnGUI(){
        if(GUI.Button(new Rect((Screen.width - 140) /2, 100, 140, 30), "Gameplay prototype"))
            Application.LoadLevel(1);
        if(GUI.Button(new Rect((Screen.width - 100) /2, 135, 100, 30), "Charger AI"))
            Application.LoadLevel(2);
        else if(GUI.Button(new Rect((Screen.width - 100) /2, 170, 100, 30), "Imp AI"))
            Application.LoadLevel(3);
        else if(GUI.Button(new Rect((Screen.width - 100) /2, 205, 100, 30), "Teleporter AI"))
            Application.LoadLevel(4);
        //else if(GUI.Button(new Rect((Screen.width - 100) /2, 205, 100, 30), "Tank AI"))
            //Application.LoadLevel(4);
        //else if(GUI.Button(new Rect((Screen.width - 100) /2, 240, 100, 30), "Flying thing AI"))
           //Application.LoadLevel(5);
        else if(GUI.Button(new Rect((Screen.width - 100) /2, 240, 100, 30), "Exit"))
            Application.Quit();
    }
}
