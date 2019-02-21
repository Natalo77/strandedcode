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
    private float playerMinPower = 0;
    public float playerCurrentPower;
    
    private float playerMaxO2 = 100;
    private float playerMinO2 = 0;
    public float playerCurrentO2;
    public int playerO2Int; //convert float to int. | to display as whole number

    private float playerMaxHunger = 100;
    private float playerMinHunger = 0;
    public float playerCurrentHunger;
    public int playerHungerInt; //convert float to int. | to display as whole number


    //Text Update stuff for testing purpose on Player HUD
    public Text textUpdateO2;
    public Text textUpdateHunger;

    public bool power, O2, hunger;
    public float multiplier;


    // Use this for initialization
    void Start () {
        // playerCurrentHP = playerMaxHP;
        playerCurrentPower = playerMaxPower;
        playerCurrentO2 = playerMaxO2;
        playerCurrentHunger = playerMaxHunger;
        playerCurrentHP = playerMaxHP;

        power = true;
        O2 = true;
        hunger = true;
	}
	
	// Update is called once per frame
	void Update () {

        // Call DecreaseNeeds function
        DecreaseNeeds(power, O2, hunger);

        //If player have 0 health = dead
        if (playerCurrentHP <= 0)
        {
            GameStateController.Instance.endGame();
        }

        // Set values to max value if they go over
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
        // Set values to min values if they go under
        if (playerCurrentHunger <= float.Epsilon)
        {
            playerCurrentHunger = playerMinHunger;
        }
        if (playerCurrentO2 <= float.Epsilon)
        {
            playerCurrentO2 = playerMinO2;
        }
        if (playerCurrentPower <= float.Epsilon)
        {
            playerCurrentPower = playerMinPower;
        }

        //UpdateText();
        
        //Reduce movement speed if any need is below 25.

        if (playerCurrentPower > 25.0f || playerCurrentO2 > 25.0f || playerCurrentHunger > 25.0f)
        {
            gameObject.GetComponent<Player_Movement>().movementSpeed = 15;
        }
        if (playerCurrentPower <= 25.0f || playerCurrentO2 <= 25.0f || playerCurrentHunger <= 25.0f)
        {
            gameObject.GetComponent<Player_Movement>().movementSpeed = 5;
        }

        //If oxygen or hunger run out, reduce health.
        if (playerCurrentO2 <= float.Epsilon || playerCurrentHunger <= float.Epsilon)
        {
            playerCurrentHP -= Time.deltaTime;
            playerHPInt = (int)playerCurrentHP;
        }
    }
    /*
    Boolean variables decide if the values should be decreased,
    If needs reach 0 then bool = false? | This will stop the decreasement of values when they reach 0
    If HUD disabled & flashlight is off power = false?
    */ 
    public void DecreaseNeeds(bool power, bool O2, bool hunger)
    {
        // Decreasing Hunger/Power/O2 per second
        if (power)
        {
            playerCurrentPower -= Time.deltaTime * multiplier;
        }
        if (O2)
        {
            playerCurrentO2 -= Time.deltaTime * multiplier;
            playerO2Int = (int)playerCurrentO2;
        }
        if (hunger)
        {
            playerCurrentHunger -= Time.deltaTime * multiplier;
            playerHungerInt = (int)playerCurrentHunger;
        }
    }

}
