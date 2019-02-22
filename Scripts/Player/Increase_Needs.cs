using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Increase_Needs : MonoBehaviour {

    private Player_Inventory playerInventory;
    private Player_Needs playerNeeds;

    // Use this for initialization
    void Start () {
        playerInventory = GetComponent<Player_Inventory>();
        playerNeeds = GetComponent<Player_Needs>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (playerInventory.getHasPickup(Player_Inventory.Pickups.Food))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                playerInventory.usePickup(Player_Inventory.Pickups.Food);
                playerNeeds.playerCurrentHunger += 25.0f;
                Debug.Log("Food Eaten");
            }
        }

        if (playerInventory.getHasPickup(Player_Inventory.Pickups.Oxygen))
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                playerInventory.usePickup(Player_Inventory.Pickups.Oxygen);
                playerNeeds.playerCurrentO2 += 25.0f;
                Debug.Log("Oxygen Added");
            }
        }

        if (playerInventory.getHasPickup(Player_Inventory.Pickups.Power))
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                playerInventory.usePickup(Player_Inventory.Pickups.Power);
                playerNeeds.playerCurrentPower += 25.0f;
                Debug.Log("Power Added");
            }
        }


        // Restraining max needs
        if (playerNeeds.playerCurrentHP > 100.0f)
        {
            playerNeeds.playerCurrentHP = playerNeeds.playerMaxHP;
        }
        if (playerNeeds.playerCurrentHunger > 100.0f)
        {
            playerNeeds.playerCurrentHunger = playerNeeds.playerMaxHunger;
        }
        if (playerNeeds.playerCurrentO2 > 100.0f)
        {
            Debug.Log("Resetting O2");
            playerNeeds.playerCurrentO2 = playerNeeds.playerMaxO2;
        }
        if (playerNeeds.playerCurrentPower > 100.0f)
        {
            playerNeeds.playerCurrentPower = playerNeeds.playerMaxPower;
        }
    }
}
