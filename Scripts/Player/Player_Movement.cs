using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody player_RB;
    Animator player_Anim;
    Transform player_Trans;
    Camera player_Cam;

    public float playerInputH;
    public float playerInputV;

    private bool canUseMovementAbilities = true;

    public float movementSpeed;

    // Use this for initialization
    void Start()
    {
        player_RB = GetComponent<Rigidbody>();
        player_Anim = GetComponent<Animator>();
        player_Trans = GetComponent<Transform>();
        player_Cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //DEBUG LOGGING
        //Debug.Log("PlayerMovement: isMoving: " + GetComponentInChildren<Animator>().GetBool("isMoving"));

        playerInputH = Input.GetAxis("Horizontal");
        playerInputV = Input.GetAxis("Vertical");

        int scale = 1;

        //Dash!
        if(Input.GetButtonDown("Dash") && canUseMovementAbilities)
        {
            scale = 5;
        }

        Vector3 camPos = player_Cam.transform.position;
        if (Mathf.Abs( playerInputH) > 0.0f || Mathf.Abs( playerInputV) > 0.0f)
        {
            Vector3 lookAtPosition = new Vector3(player_Trans.position.x + playerInputH, player_Trans.position.y, player_Trans.position.z + playerInputV);
            lookAtPosition = lookAtPosition - player_Trans.position;

            if (!player_Trans.forward.Equals(lookAtPosition))
            {
                player_Trans.forward = lookAtPosition;
            }
            
        }
        player_Cam.transform.position = camPos;

        //Update animator controller.
        if ( Mathf.Abs( playerInputH) > 0.1f || Mathf.Abs( playerInputV) > 0.1f)
        {
            GetComponentInChildren<Animator>().SetBool("isMoving", true);
        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("isMoving", false);
        }

        player_RB.velocity = new Vector3(movementSpeed * playerInputH * scale, 0, movementSpeed * playerInputV * scale);

        player_Cam.transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    public void setCanUseMovementAbilities(bool canUse)
    {
        this.canUseMovementAbilities = canUse;
    }


}
