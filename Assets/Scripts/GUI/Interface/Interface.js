var PGHealth:float;
var PGMaxHealth:float;
var bgImage: Texture2D;
var fgImage: Texture2D;
var HealtMana_Level: float;
var rectTop: float;
var rectLeft: float;

function Update(){
    //rectLeft=0;
    //rectTop=Screen.height-bgImage.height;
    if(PGHealth>0){
        HealtMana_Level=PGHealth/PGMaxHealth;
    }
}

function OnGUI() {
    if(PGHealth>0){
        GUI.DrawTexture(new Rect(rectLeft, rectTop, bgImage.width, bgImage.height), bgImage);
       
        var fillHeight: float = bgImage.height * HealtMana_Level;
        var heightDiff: float = bgImage.height - fillHeight;

        GUI.BeginGroup(new Rect(rectLeft, rectTop + heightDiff, bgImage.width, fillHeight));
        GUI.DrawTexture(new Rect(0, -heightDiff, bgImage.width, bgImage.height), fgImage);
        GUI.EndGroup();
    }
}