using UnityEngine;
using System.Collections;

public class InterfaceGUI : MonoBehaviour{
    public PlayerControls playerControls;

    public float Health_Level;
    public Texture2D playerHealth;

    public float pHealthRectTop;
    public float pHealthRectLeft;
	
	public float Mana_Level;
	public Texture2D playerMana;
	
	public float pManaRectTop;
	public float pManaRectLeft;

    void Init(){
        playerControls = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
    }

    void Start(){
        Init();
        pHealthRectTop = Screen.height - playerHealth.height;
		pManaRectTop = Screen.height - playerMana.height;
    }

    void Update(){
        Health_Level=(float)playerControls.health/playerControls.maxHealth;
		Mana_Level=(float)playerControls.mana/playerControls.maxMana;
    }

	void OnGUI(){
        float HealthFillHeight  = playerHealth.height * Health_Level;
        float healthHeightDiff = playerHealth.height - HealthFillHeight;
        GUI.BeginGroup(new Rect(pHealthRectLeft, pHealthRectTop + healthHeightDiff, playerHealth.width, HealthFillHeight));
        GUI.DrawTexture(new Rect(0, -healthHeightDiff, playerHealth.width, playerHealth.height), playerHealth);
        GUI.EndGroup();
		float ManaFillHeight = playerMana.height *Mana_Level;
		float manaHeightDiff = playerMana.height - ManaFillHeight;
		GUI.BeginGroup(new Rect(pManaRectLeft, pManaRectTop + manaHeightDiff, playerMana.width, ManaFillHeight));
		GUI.DrawTexture(new Rect(0, -manaHeightDiff, playerMana.width, playerMana.height), playerMana);
		GUI.EndGroup();
    }
}