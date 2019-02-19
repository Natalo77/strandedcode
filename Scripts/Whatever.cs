using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whatever : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //needs failed.
        GameStateController.Instance.endGame();
	}
	
	// Update is called once per frame
	void Update () {
		for (int x = 0; x < 10; x++)
        {
            Debug.Log(x + "1");
            Debug.Log("1");

        }
	}
}
