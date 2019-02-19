using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Needs : MonoBehaviour {

    // Not sure if we need HP for now so I will just comments it out.
   // public float playerMaxHP = 100.0f;
   // public float playerCurrentHP;

    public float playerMaxStamina = 100;
    public float playerCurrentStamina;
    
    public float playerMaxO2 = 100;
    public float playerCurrentO2;
    private int playerO2Int; //convert float to int. | to display as whole number

    public float playerMaxHunger = 100;
    public float playerCurrentHunger;
    private int playerHungerInt; //convert float to int. | to display as whole number

    public float playerMaxHydration = 100;
    public float playerCurrentHydration;
    private int playerHydrationInt; //convert float to int. | to display as whole number

    private float timer = 0.0f;
    private const float time = 0.1f; // 1 second

    //Text Update stuff for testing purpose on Player HUD
    public Text textUpdateO2;
    public Text textUpdateHunger;
    public Text textUpdateHydration;

    // Use this for initialization
    void Start () {
        //playerCurrentHP = playerMaxHP;
        playerCurrentStamina = playerMaxStamina;
        playerCurrentO2 = playerMaxO2;
        playerCurrentHunger = playerMaxHunger;
        playerCurrentHydration = playerMaxHydration;

        //playerCurrentO2 = Mathf.Round(playerCurrentO2);
        
	}
	
	// Update is called once per frame
	void Update () {
        /*//If player have 0 health = dead
        if (playerCurrentHP <= 0)
        {
            Destroy(this.gameObject);
        }*/

        // Decreasing Hunger/Hydration/O2 overtime set by "time"
        playerCurrentO2 -= time * Time.deltaTime;
        playerO2Int = (int)playerCurrentO2;

        playerCurrentHunger -= time * Time.deltaTime;
        playerHungerInt = (int)playerCurrentHunger;

        playerCurrentHydration -= time * Time.deltaTime;
        playerHydrationInt = (int)playerCurrentHydration;


        UpdateText();
	}

    //Update Text on HUD
    public void UpdateText()
    {
        textUpdateO2.text = "O2: " + playerO2Int;
        textUpdateHunger.text = "Hunger: " + playerHungerInt;
        textUpdateHydration.text = "Hydration: " + playerHungerInt;
    }

}
