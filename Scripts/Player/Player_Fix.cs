using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Fix : MonoBehaviour {

    private Player_Inventory playerInventory;
    private UI_Controller uiController;

    private bool hasExt, hasHammer, hasPipe, hasSpanner, hasSpring;
    private bool engine, lifeSupport, reactor, controls, battery;

    private Text fixEngine, fixLifeSupport, fixReactor, fixControls, fixBattery;
    private Text reqExt, reqHammer, reqPipe, reqSpanner, reqSpring;
    private Text engineFixed, lifeSupportFixed, reactorFixed, controlsFixed, batteryFixed;

    // Use this for initialization
    void Start()
    {
        //gameObject.GetComponent<Player_HUD>().showFix();

        playerInventory = GetComponent<Player_Inventory>();
        uiController = GameObject.Find("UI_Controller").GetComponent<UI_Controller>();

        fixEngine = uiController.fixEngine;
        fixLifeSupport = uiController.fixLifeSupport;
        fixReactor = uiController.fixReactor;
        fixControls = uiController.fixControls;
        fixBattery = uiController.fixBattery;

        reqExt = uiController.reqExt;
        reqHammer = uiController.reqHammer;
        reqPipe = uiController.reqPipe;
        reqSpanner = uiController.reqSpanner;
        reqSpring = uiController.reqSpring;

        engineFixed = uiController.engineFixed;
        lifeSupportFixed = uiController.lifeSupportFixed;
        reactorFixed = uiController.reactorFixed;
        controlsFixed = uiController.controlsFixed;
        batteryFixed = uiController.batteryFixed;
    }

    // Update is called once per frame
    void Update()
    {
        // Setting booleans depending on player inventory | If they have the item or not
        hasExt = playerInventory.getHasShipPart(Player_Inventory.ShipPart.Extinguisher);
        hasHammer = playerInventory.getHasShipPart(Player_Inventory.ShipPart.Hammer);
        hasPipe = playerInventory.getHasShipPart(Player_Inventory.ShipPart.Pipe);
        hasSpanner = playerInventory.getHasShipPart(Player_Inventory.ShipPart.Spanner);
        hasSpring = playerInventory.getHasShipPart(Player_Inventory.ShipPart.Spring);

        if (engine && lifeSupport && reactor && controls & battery)
        {
            // End game animation?? Possibly a Coroutine
            GameStateController.Instance.endGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FixEngine")
        {
            // If engine is not fixed and player does not have part
            if (!engine && !hasExt)
            {
                reqExt.enabled = true;
            }
            // If engine fixed
            if (engine)
            {
                engineFixed.enabled = true;
            }
        }
        if (other.gameObject.tag == "FixLifeSupport")
        {
            // If life support is not fixed and player does not have part
            if (!lifeSupport && !hasHammer)
            {
                reqHammer.enabled = true;
            }
            // Life support fixed
            if (lifeSupport)
            {
                lifeSupportFixed.enabled = true;
            }
        }
        if (other.gameObject.tag == "FixReactor")
        {
            // If reactor is not fixed and player does not have part
            if (!reactor && !hasPipe)
            {
                reqPipe.enabled = true;
            }
            // Reactor fixed
            if (reactor)
            {
                reactorFixed.enabled = true;
            }
        }
        if (other.gameObject.tag == "FixControls")
        {
            // If controls are not fixed and player does not have part
            if (!controls && !hasSpanner)
            {
                reqSpanner.enabled = true;
            }
            // Controls fixed
            if (controls)
            {
                controlsFixed.enabled = true;
            }
        }
        if (other.gameObject.tag == "FixBattery")
        {
            // If battery is not fixed and player does not have part
            if (!battery && !hasSpring)
            {
                reqSpring.enabled = true;
            }
            // Battery is fixed
            if (battery)
            {
                batteryFixed.enabled = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "FixEngine")
        {
            // If engine is not fixed
            if (!engine)
            {
                // If player has part
                if (hasExt)
                {
                    fixEngine.enabled = true;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        // Fix Ship | Audio - Animation
                        // Use part and remove from inventory
                        playerInventory.useShipPart(Player_Inventory.ShipPart.Extinguisher);
                        fixEngine.enabled = false;
                        // Engine fixed
                        engine = true;
                    }
                }
            }
        }
        if (other.gameObject.tag == "FixLifeSupport")
        {
            // If life support is not fixed
            if (!lifeSupport)
            {
                // If player has part
                if (hasHammer)
                {
                    fixLifeSupport.enabled = true;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        // Fix Ship | Audio - Animation
                        // Use part and remove from inventory
                        playerInventory.useShipPart(Player_Inventory.ShipPart.Hammer);
                        fixLifeSupport.enabled = false;
                        // Life Support fixed
                        lifeSupport = true;
                    }
                }
            }
        }
        if (other.gameObject.tag == "FixReactor")
        {
            // If reactor is not fixed
            if (!reactor)
            {
                // If player has part
                if (hasPipe)
                {
                    fixReactor.enabled = true;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        // Fix Ship | Audio - Animation
                        // Use part and remove from inventory
                        playerInventory.useShipPart(Player_Inventory.ShipPart.Pipe);
                        fixReactor.enabled = false;
                        // Reactor fixed
                        reactor = true;
                    }
                }
            }
        }
        if (other.gameObject.tag == "FixControls")
        {
            // If controls are not fixed
            if (!controls)
            {
                // If player has part
                if (hasSpanner)
                {
                    fixControls.enabled = true;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        // Fix Ship | Audio - Animation
                        // Use part and remove from inventory
                        playerInventory.useShipPart(Player_Inventory.ShipPart.Spanner);
                        fixControls.enabled = false;
                        // Controls fixed
                        controls = true;
                    }
                }
            }
        }
        if (other.gameObject.tag == "FixBattery")
        {
            // If battery is not fixed
            if (!battery)
            {
                // If player has part
                if (hasSpring)
                {
                    fixBattery.enabled = true;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        // Fix Ship | Audio - Animation
                        // Use part and remove from inventory
                        playerInventory.useShipPart(Player_Inventory.ShipPart.Spring);
                        fixBattery.enabled = false;
                        // Battery fixed
                        battery = true;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "FixEngine")
        {

            fixEngine.enabled = false;
            reqExt.enabled = false;
            engineFixed.enabled = false;
        }
        if (other.gameObject.tag == "FixLifeSupport")
        {
            fixLifeSupport.enabled = false;
            reqHammer.enabled = false;
            lifeSupportFixed.enabled = false;
        }
        if (other.gameObject.tag == "FixReactor")
        {
            fixReactor.enabled = false;
            reqPipe.enabled = false;
            reactorFixed.enabled = false;
        }
        if (other.gameObject.tag == "FixControls")
        {
            fixControls.enabled = false;
            reqSpanner.enabled = false;
            controlsFixed.enabled = false;
        }
        if (other.gameObject.tag == "FixBattery")
        {

            fixBattery.enabled = false;
            reqSpring.enabled = false;
            batteryFixed.enabled = false;
        }
    }
}