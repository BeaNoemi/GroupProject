using UnityEngine;
using System.Collections;

public class InterfaceGUI : MonoBehaviour{
    public PlayerControls playerControls;

    public float Health_Level;
    public Texture2D playerHealth;

    public float pHealthRectTop;
    public float pHealthRectLeft;
	
    void Init(){
        playerControls = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
    }

    void Start(){
        Init();
        pHealthRectTop = Screen.height - playerHealth.height;
    }

    void Update(){
        Health_Level=(float)playerControls.health/playerControls.maxHealth;
    }

	void OnGUI(){
        float HealthFillHeight  = playerHealth.height * Health_Level;
        float healthHeightDiff = playerHealth.height - HealthFillHeight;
        GUI.BeginGroup(new Rect(pHealthRectLeft, pHealthRectTop + healthHeightDiff, playerHealth.width, HealthFillHeight));
        GUI.DrawTexture(new Rect(0, -healthHeightDiff, playerHealth.width, playerHealth.height), playerHealth);
        GUI.EndGroup();
    }
}