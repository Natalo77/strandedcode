using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {
    Rigidbody player_RB;
    Animator player_Anim;

    private float playerInputH;
    private float playerInputV;

    public float movementSpeed;

	// Use this for initialization
	void Start () {
        player_RB = GetComponent<Rigidbody>();
        player_Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        playerInputH = Input.GetAxis("Horizontal");
        playerInputV = Input.GetAxis("Vertical");
        player_RB.velocity = new Vector3(movementSpeed * playerInputH, 0, movementSpeed * playerInputV);
		
	}
}
