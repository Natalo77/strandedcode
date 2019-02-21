using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_HUD : MonoBehaviour {
    
    //Text Update stuff for testing purpose on Player HUD
    public Text textUpdateHP;
    public Text textUpdateO2;
    public Text textUpdateHunger;
    
    Player_Needs pNeeds; // will be needed to call some variable from Player_Needs

    private bool flashLightCanBeOn;
    private bool flashLightOn;
    private bool flicker;
    private bool HUDisOn;

    private HUD_Flicker hudFlicker;

    private void Start() 
    {
        pNeeds = GetComponent<Player_Needs>();
        hudFlicker = GetComponent<HUD_Flicker>();
        flashLightCanBeOn = true;
        flashLightOn = false;
        flicker = false;
        HUDisOn = true;
    }

    // Update is called once per frame
    void Update ()
    {
        //Only run update loop if HUD is on.
        if (HUDisOn)
        {
            UpdateText();
            if (pNeeds)
            {
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    gameObject.GetComponent<Canvas>().enabled = !gameObject.GetComponent<Canvas>().enabled;
                }
            }
        }

        //Debug.Log("flashLight On: " + flashLightOn + ", Can be on: " + flashLightCanBeOn);

        if(Input.GetKeyDown(KeyCode.Q))
        {
            toggleFlashLight();
        }
        

    }

    //Update Text on HUD
    public void UpdateText()
    {
        textUpdateO2.text = "O2: " + pNeeds.playerO2Int;
        textUpdateHunger.text = "Hunger: " + pNeeds.playerHungerInt;
        textUpdateHP.text = "HP: " + pNeeds.playerHPInt;
    }

    public void DisableFlashlight()
    {
        this.flashLightCanBeOn = false;
    }

    public void enableFlashlight()
    {
        this.flashLightCanBeOn = true;
    }

    public void toggleFlashLight()
    {
        if (flashLightCanBeOn && !flashLightOn || !flashLightCanBeOn && flashLightOn || flashLightCanBeOn && flashLightOn)
        {
            this.flashLightOn = !this.flashLightOn;

            GetComponentInChildren<Light>().enabled = this.flashLightOn;
        }
    }

    public bool isFlashlightOn()
    {
        return this.flashLightOn;
    }

    public void flashLightOFF()
    {
        this.flashLightOn = false;
    }

    public void flashLightON()
    {
        this.flashLightOn = true;
    }

    public void flickerOn()
    {
        if (!flicker)
        {
            this.flicker = true;
            hudFlicker.enabled = true;
        }
    }

    public void flickerOff()
    {
        if (flicker)
        {
            this.flicker = false;
            hudFlicker.exit();
        }
    }

    public void setHUDIsOn(bool on)
    {
        this.HUDisOn = on;
        gameObject.GetComponentInChildren<Canvas>().enabled = on;

    }

    public bool isHUDOn()
    {
        return this.HUDisOn;
    }

    public void showPickup(string itemName)
    {
        //display a pickup item with the item name here.
    }

    public void showFix()
    {
        //display a key here.
    }


}
