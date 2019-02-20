using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Needs : MonoBehaviour {

    // Not sure if we need HP for now so I will just comments it out.
    private float playerMaxHP = 100;
    public float playerCurrentHP;
    public int playerHPInt; //conver float to int. | to display as whole number

    private float playerMaxPower = 100;
    public float playerCurrentPower;
    
    private float playerMaxO2 = 100;
    public float playerCurrentO2;
    public int playerO2Int; //convert float to int. | to display as whole number

    private float playerMaxHunger = 100;
    public float playerCurrentHunger;
    public int playerHungerInt; //convert float to int. | to display as whole number

    // Use this for initialization
    void Start () {
        // playerCurrentHP = playerMaxHP;
        playerCurrentPower = playerMaxPower;
        playerCurrentO2 = playerMaxO2;
        playerCurrentHunger = playerMaxHunger;
        playerCurrentHP = playerMaxHP;

        //playerCurrentO2 = Mathf.Round(playerCurrentO2);
        
	}
	
	// Update is called once per frame
	void Update () {
        //If player have 0 health = dead
        if (playerCurrentHP <= 0)
        {
            GameStateController.Instance.endGame();
        }

        playerHPInt = (int)playerCurrentHP;

        // Decreasing Hunger/Hydration/O2 overtime set by "time"
        playerCurrentO2 -= Time.deltaTime;
        playerO2Int = (int)playerCurrentO2;

        playerCurrentHunger -= Time.deltaTime;
        playerHungerInt = (int)playerCurrentHunger;

      
        playerCurrentPower -= Time.deltaTime;


        if (playerCurrentHP > 100.0f)
        {
            playerCurrentHP = playerMaxHP;
        }
        if (playerCurrentHunger > 100.0f)
        {
            playerCurrentHunger = playerMaxHunger;
        }
        if (playerCurrentO2 > 100.0f)
        {
            playerCurrentO2 = playerMaxO2;
        }
        if (playerCurrentPower > 100.0f)
        {
            playerCurrentPower = playerMaxPower;
        }

        //UpdateText();

        if (playerCurrentPower > 25.0f || playerCurrentO2 > 25.0f || playerCurrentHunger > 25.0f)
        {
            gameObject.GetComponent<Player_Movement>().movementSpeed = 15;
        }

        if (playerCurrentPower <= 25.0f || playerCurrentO2 <= 25.0f || playerCurrentHunger <= 25.0f)
        {
            gameObject.GetComponent<Player_Movement>().movementSpeed = 5;
        }
	}
}
