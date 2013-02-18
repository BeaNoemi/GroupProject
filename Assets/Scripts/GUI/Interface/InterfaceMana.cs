using UnityEngine;
using System.Collections;

public class InterfaceMana : MonoBehaviour{
    public PlayerControls playerControls;

	public float Mana_Level;
	public Texture2D playerMana;
	
	public float pManaRectTop;
	public float pManaRectLeft;

    void Init(){
        playerControls = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
    }

    void Start(){
        Init();
		pManaRectTop = Screen.height - playerMana.height;
    }

    void Update(){
		Mana_Level=(float)playerControls.mana/playerControls.maxMana;
    }

	void OnGUI(){
		float ManaFillHeight = playerMana.height *Mana_Level;
		float manaHeightDiff = playerMana.height - ManaFillHeight;
		GUI.BeginGroup(new Rect(pManaRectLeft, pManaRectTop + manaHeightDiff, playerMana.width, ManaFillHeight));
		GUI.DrawTexture(new Rect(0, -manaHeightDiff, playerMana.width, playerMana.height), playerMana);
		GUI.EndGroup();
    }
}