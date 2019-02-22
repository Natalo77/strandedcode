using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Needs : MonoBehaviour {

    [HideInInspector]
    public float playerMaxHP = 100;
    [HideInInspector]
    public float playerCurrentHP;
    public int playerHPInt; //conver float to int. | to display as whole number

    [HideInInspector]
    public float playerMaxPower = 100;
    public float playerCurrentPower;

    [HideInInspector]
    public float playerMaxO2 = 100;
    [HideInInspector]
    public float playerCurrentO2;
    public int playerO2Int; //convert float to int. | to display as whole number

    [HideInInspector]
    public float playerMaxHunger = 100;
    [HideInInspector]
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

        playerHPInt = (int)playerCurrentHP;
        // Call DecreaseNeeds function
        DecreaseNeeds(power, O2, hunger);

        //TESTFUNCTION
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (playerCurrentPower > 25.0f)
            {
                playerCurrentPower = 25.0f;
            }
            else if (playerCurrentPower >= 1.0f && playerCurrentPower <= 25.0f)
            {
                playerCurrentPower = 1.0f;
            }
            else
            {
                playerCurrentPower = 100.0f;
            }
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            playerCurrentPower = 25.0f;
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
            playerCurrentO2 = 1.0f;
        }

        //If player have 0 health = dead
        if (playerCurrentHP <= 0)
        {
            GameStateController.Instance.endGame();
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
        }
        

        //If HP > 50 and O2 > 25 increase health.
        if (playerCurrentHunger > 50 && playerCurrentO2 > 25)
        {
            playerCurrentHP += Time.deltaTime;
        }

        //if playerPower is over 25, everything is fine.
        if(playerCurrentPower > 25.0f)
        {
            //Debug.Log("PlayerNeeds: > 25");
            gameObject.GetComponent<Player_HUD>().flickerOff();
            gameObject.GetComponent<Player_Movement>().setCanUseMovementAbilities(true);
            gameObject.GetComponent<Player_HUD>().enableFlashlight();
            gameObject.GetComponent<Player_HUD>().enableFlashlight();
        } //else if between 25 and 0, flicker.
        else if(playerCurrentPower <= 25.0f && playerCurrentPower >= float.Epsilon)
        {
            //Debug.Log("PlayerNeeds: 25 and 0");
            gameObject.GetComponent<Player_HUD>().flickerOn();
            gameObject.GetComponent<Player_HUD>().enableFlashlight();
            gameObject.GetComponent<Player_HUD>().enableFlashlight();
            gameObject.GetComponent<Player_Movement>().setCanUseMovementAbilities(true);
        } //else is 0 so turn off.
        else
        {
            //Debug.Log("PlayerNeeds:  0");
            gameObject.GetComponent<Player_HUD>().flickerOff();
            gameObject.GetComponent<Player_Movement>().setCanUseMovementAbilities(false);
            gameObject.GetComponent<Player_HUD>().setHUDIsOn(false);
            gameObject.GetComponent<Player_HUD>().DisableFlashlight();
            gameObject.GetComponent<Player_HUD>().toggleFlashLight();
        }

        //Constraints.
        if(playerCurrentHunger <= float.Epsilon)
        {
            playerCurrentHunger = 0.0f;
        }
        if(playerCurrentO2 <= float.Epsilon)
        {
            playerCurrentO2 = 0.0f;
        }
        if(playerCurrentPower <= float.Epsilon)
        {
            playerCurrentPower = 0.0f;
        }

        playerHPInt = (int)playerCurrentHP;
    }


    public void DecreaseNeeds(bool power, bool O2, bool hunger)
    {
        // Decreasing Hunger/Power/O2 overtime set by "time"
        playerCurrentO2 -= Time.deltaTime;
        

        if (Mathf.Abs(gameObject.GetComponent<Player_Movement>().playerInputH) > 0.0f || Mathf.Abs(gameObject.GetComponent<Player_Movement>().playerInputV) > 0.0f)
        {
            playerCurrentHunger -= Time.deltaTime;
        }
        playerHungerInt = (int)playerCurrentHunger;
        playerO2Int = (int)playerCurrentO2;

        if(gameObject.GetComponent<Player_HUD>().isHUDOn())
        {
            Debug.Log("PlayerNeeds: Decreasing Power: " + playerCurrentPower);

            int scale = 1;
            if(gameObject.GetComponent<Player_HUD>().isFlashlightOn())
            {
                scale = 2;
            }

            playerCurrentPower -= Time.deltaTime * scale;
        }
    }
}