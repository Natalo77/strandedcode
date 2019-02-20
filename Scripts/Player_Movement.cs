using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody player_RB;
    Animator player_Anim;

    private float playerInputH;
    private float playerInputV;

    public float movementSpeed;

    // Use this for initialization
    void Start()
    {
        player_RB = GetComponent<Rigidbody>();
        player_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInputH = Input.GetAxis("Horizontal");
        playerInputV = Input.GetAxis("Vertical");
        player_RB.velocity = new Vector3(movementSpeed * playerInputH, 0, movementSpeed * playerInputV);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ship" || other.gameObject.tag == "Building")
        {
            other.GetComponent<MeshRenderer>().enabled = false;
        }

        if (other.gameObject.tag == "Food")
        {
            gameObject.GetComponent<Player_Needs>().playerCurrentHunger += 25.0f;
        }

        if (other.gameObject.tag == "PowerCell")
        {
            gameObject.GetComponent<Player_Needs>().playerCurrentPower += 25.0f;
        }

        if (other.gameObject.tag == "OxygenTank")
        {
            gameObject.GetComponent<Player_Needs>().playerCurrentO2 += 25.0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Oxygen")
        {
            gameObject.GetComponent<Player_Needs>().playerCurrentO2 += Time.deltaTime * 5;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ship" || other.gameObject.tag == "Building")
        {
            other.GetComponent<MeshRenderer>().enabled = true;
        }
    }

}
