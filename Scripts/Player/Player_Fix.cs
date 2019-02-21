using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fix : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Player_HUD>().showFix();
	}
	

}
