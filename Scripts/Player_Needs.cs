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


    //Text Update stuff for testing purpose on Player HUD
    public Text textUpdateO2;
    public Text textUpdateHunger;

    public bool power, O2, hunger;


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

        playerHPInt = (int)playerCurrentHP;

        

      
        



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
        if(playerCurrentHunger <= 0.0f)
        {
            playerCurrentHunger = 0.0f;
        }
        if (playerCurrentO2 <= 0.0f)
        {
            playerCurrentO2 = 0.0f;
        }
        if(playerCurrentPower <= 0.0f)
        {
            playerCurrentPower = 0.0f;
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
            playerCurrentHP -= Time.deltaTime * 2;
            playerHPInt = (int)playerCurrentHP;
        }

        //Increase health if oxygen or hunger is above a value.
        if(playerCurrentHunger >= 50.0f && playerCurrentO2 >= 25.0f)
        {
            playerCurrentHP += Time.deltaTime * 2;
            playerHPInt = (int)playerCurrentHP;
        }

        //If power runs out, disable abilities.
        if(playerCurrentPower <= float.Epsilon)
        {
            //PlayerMovInteract.DisableMovementAbilities.
            //PlayerHUD.Disableflashlight
            //PlayerHUD.FlickerHUD
        }



    }


    public void DecreaseNeeds(bool power, bool O2, bool hunger)
    {
        // Decreasing Hunger/Hydration/O2 overtime set by "time"
        playerCurrentO2 -= Time.deltaTime;
        
        //Only decrease hunger if the player is moving.
        if (Mathf.Abs( gameObject.GetComponent<Player_Movement>().playerInputH) > 0.0f || Mathf.Abs( gameObject.GetComponent<Player_Movement>().playerInputV) > 0.0f)
        {
            playerCurrentHunger -= Time.deltaTime;
        }
       

        //Only decrease if the HUD is on.
        //if(Player_HUD.isOn())
        //{
            int scale = 1;
            //Player_HUD.FlashlightIsOn ? scale = 2;
            playerCurrentPower -= Time.deltaTime * scale;
        //}

        //Convert to Int values
        playerO2Int = (int)playerCurrentO2;
        playerHungerInt = (int)playerCurrentHunger;

        
    }

}
