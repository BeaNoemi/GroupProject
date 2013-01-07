using UnityEngine;
using System.Collections;

public class Pet : FriendlyMob {

	void Start(){
        InitEntity("Friend", enemy, 100, 10, 10, 40, 1.5f);
    }
}
