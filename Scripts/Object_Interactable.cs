using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object_Interactable : MonoBehaviour {
    public Transform other; // interactavle object
    private Player_Needs playerNeeds;

    public GameObject showText;

   //public Texture BoxTexture; // Drag a Texture onto this item in the Inspector
   // GUIContent content;

	// Use this for initialization
	void Start () {
        //content = new GUIContent("This is a box", BoxTexture, "This is a tooltip");
        GameObject playerNeedsOb = GameObject.FindWithTag("Player");
        if (playerNeedsOb != null)
        {
            playerNeeds = playerNeeds.GetComponent<Player_Needs>();
        }
        if (playerNeeds == null)
        {
            Debug.Log("Cannot find 'GameController' Script");
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (other)
        {
            GameObject player = GameObject.FindWithTag("Player");
            Player_Needs refillNeed = player.GetComponent<Player_Needs>();
            float dist = Vector3.Distance(other.position, transform.position);
            print("Distance to other: " + dist);
            if(dist < 5)
            {
                Debug.Log("Player is close, render the box naw");
                showText.SetActive(!false);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    refillNeed.playerCurrentO2 = 100.2f;
                }
            }
        }
	}
}
