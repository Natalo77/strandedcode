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

    //private float timer = 0.0f;
    //private const float time = 0.1f; // 1 second

    //Text Update stuff for testing purpose on Player HUD
    public Text textUpdateO2;
    public Text textUpdateHunger;
    //public Text textUpdateHydration;

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
            Destroy(this.gameObject);
        }

        // Decreasing Hunger/Hydration/O2 overtime set by "time"
        playerCurrentO2 -= 2 * Time.deltaTime;
        playerO2Int = (int)playerCurrentO2;

        playerCurrentHunger -= 2 * Time.deltaTime;
        playerHungerInt = (int)playerCurrentHunger;

        playerCurrentPower -= 2 * Time.deltaTime;

        //UpdateText();

        if (playerCurrentPower > 75.0f || playerCurrentO2 > 75.0f || playerCurrentHunger > 75.0f)
        {
            gameObject.GetComponent<Player_Movement>().movementSpeed = 15;
        }

        if (playerCurrentPower <= 75.0f || playerCurrentO2 <= 75.0f || playerCurrentHunger <= 75.0f)
        {
            gameObject.GetComponent<Player_Movement>().movementSpeed = 11;
        }

        if (playerCurrentPower <= 50.0f || playerCurrentO2 <= 50.0f || playerCurrentHunger <= 50.0f)
        {
            gameObject.GetComponent<Player_Movement>().movementSpeed = 7;
        }

        if (playerCurrentPower <= 25.0f || playerCurrentO2 <= 25.0f || playerCurrentHunger <= 25.0f)
        {
            gameObject.GetComponent<Player_Movement>().movementSpeed = 3;
        }
	}

    //Update Text on HUD | for testing purpose
    public void UpdateText()
    {        
        //textUpdateO2.text = "O2: " + playerO2Int;
        //textUpdateHunger.text = "Hunger: " + playerHungerInt;
        //textUpdateHydration.text = "Hydration: " + playerHungerInt;         
    }

}
