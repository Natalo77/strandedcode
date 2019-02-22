using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Interaction : MonoBehaviour {

    private UI_Controller uiController;
    private Player_Inventory playerInventory;
    private Text pickupFood, pickupPowerCell, pickupOxygenTank;
    private Text pickupFireExt, pickupHammer, pickupPipe, pickupSpanner, pickupSpring;
    private Text invFoodFull, invPowerFull, invOxygenFull;
    private Text invExtFull, invHammerFull, invPipeFull, invSpannerFull, invSpringFull;

    private void Start()
    {
        // Reference to the UI_Controller script
        uiController = GameObject.Find("UI_Controller").GetComponent<UI_Controller>();
        playerInventory = GetComponent<Player_Inventory>();

        // Setting the pickup item text objects
        pickupFood = uiController.pickupFood;
        pickupOxygenTank = uiController.pickupOxygenTank;
        pickupPowerCell = uiController.pickupPowerCell;

        pickupFireExt = uiController.pickupFireExt;
        pickupHammer = uiController.pickupHammer;
        pickupPipe = uiController.pickupPipe;
        pickupSpanner = uiController.pickupSpanner;
        pickupSpring = uiController.pickupSpring;

        invFoodFull = uiController.invFoodFull;
        invPowerFull = uiController.invPowerFull;
        invOxygenFull = uiController.invOxygenFull;

        invExtFull = uiController.invExtFull;
        invHammerFull = uiController.invHammerFull;
        invPipeFull = uiController.invPipeFull;
        invSpannerFull = uiController.invSpannerFull;
        invSpringFull = uiController.invSpringFull;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Disable top mesh if player enters the ship or a building
        if (other.gameObject.tag == "Ship" || other.gameObject.tag == "Building")
        {
            other.GetComponent<MeshRenderer>().enabled = false;
        }
        if (other.gameObject.tag == "Extinguisher")
        {
            if (playerInventory.getShipPartAmount(Player_Inventory.ShipPart.Extinguisher) >= 1)
            {
                invExtFull.enabled = true;
            }
        }
        if (other.gameObject.tag == "Hammer")
        {
            if (playerInventory.getShipPartAmount(Player_Inventory.ShipPart.Hammer) >= 1)
            {
                invHammerFull.enabled = true;
            }
        }
        if (other.gameObject.tag == "Metal Pipe")
        {
            if (playerInventory.getShipPartAmount(Player_Inventory.ShipPart.Pipe) >= 1)
            {
                invPipeFull.enabled = true;
            }
        }
        if (other.gameObject.tag == "Spanner")
        {
            if (playerInventory.getShipPartAmount(Player_Inventory.ShipPart.Spanner) >= 1)
            {
                invSpannerFull.enabled = true;
            }
        }
        if (other.gameObject.tag == "Spring")
        {
            if (playerInventory.getShipPartAmount(Player_Inventory.ShipPart.Spring) >= 1)
            {
                invSpringFull.enabled = true;
            }
        }
        if (other.gameObject.tag == "Food")
        {
            if (playerInventory.getPickupAmount(Player_Inventory.Pickups.Food) >= 1)
            {
                invFoodFull.enabled = true;
            }
        }
        if (other.gameObject.tag == "PowerCell")
        {
            if (playerInventory.getPickupAmount(Player_Inventory.Pickups.Power) >= 1)
            {
                invPowerFull.enabled = true;
            }
        }
        if (other.gameObject.tag == "OxygenTank")
        {
            if (playerInventory.getPickupAmount(Player_Inventory.Pickups.Oxygen) >= 1)
            {
                invOxygenFull.enabled = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // This is the on ship oxygen provider | If the player is within the radius they will gain oxygen
        if (other.gameObject.tag == "ShipOxygen")
        {
            gameObject.GetComponent<Player_Needs>().playerCurrentO2 += Time.deltaTime * 5;
        }
        // Check if the player is standing over the Food pickup item
        if (other.gameObject.tag == "Food")
        {
            // If player does not already have food in their inventory
            if (playerInventory.getPickupAmount(Player_Inventory.Pickups.Food) < 1)
            {
                // Enable the text to inform the player of the key to press to pickup food
                pickupFood.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Add food to inventory
                    playerInventory.addPickup(Player_Inventory.Pickups.Food);
                    pickupFood.enabled = false;
                    Destroy(other.gameObject);
                }
            }
        }
        // Check if the player is standing over the PowerCell pickup item
        if (other.gameObject.tag == "PowerCell")
        {
            // If player does not already have power in their inventory
            if (playerInventory.getPickupAmount(Player_Inventory.Pickups.Power) < 1)
            {
                // Enable the text to inform the player of the key to press to pickup powercell
                pickupPowerCell.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Add powercell to inventory
                    playerInventory.addPickup(Player_Inventory.Pickups.Power);
                    pickupPowerCell.enabled = false;
                    Destroy(other.gameObject);
                }
            }
        }
        // Check if the player is standing over the OxygenTank pickup item
        if (other.gameObject.tag == "OxygenTank")
        {
            if (playerInventory.getPickupAmount(Player_Inventory.Pickups.Oxygen) < 1)
            {
                // Enable the text to inform the player of the key to press to pickup oxygen tank
                pickupOxygenTank.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // If player picks up the oxygen tank | Add oxygen tank to inventory
                    playerInventory.addPickup(Player_Inventory.Pickups.Oxygen);
                    pickupOxygenTank.enabled = false;
                    Destroy(other.gameObject);
                }
            }
        }
        // Check if the player is standing over the fire Extinguisher pickup item
        if (other.gameObject.tag == "Extinguisher")
        {
            if (playerInventory.getShipPartAmount(Player_Inventory.ShipPart.Extinguisher) < 1)
            {
                // Enable the text to inform the player of the key to press to pickup fire extinguisher
                pickupFireExt.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Add fire extinguisher to inventory
                    playerInventory.addShipPart(Player_Inventory.ShipPart.Extinguisher);
                    pickupFireExt.enabled = false;
                    Destroy(other.gameObject);
                }
            }
        }
        // Check if the player is standing over the Hammer pickup item
        if (other.gameObject.tag == "Hammer")
        {
            if (playerInventory.getShipPartAmount(Player_Inventory.ShipPart.Hammer) < 1)
            {
                // Enable the text to inform the player of the key to press to pickup Hammer
                pickupHammer.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Add Hammer to inventory
                    playerInventory.addShipPart(Player_Inventory.ShipPart.Hammer);
                    pickupHammer.enabled = false;
                    Destroy(other.gameObject);
                }
            }
        }
        // Check if the player is standing over the Metal Pipe pickup item
        if (other.gameObject.tag == "Metal Pipe")
        {
            if (playerInventory.getShipPartAmount(Player_Inventory.ShipPart.Pipe) < 1)
            {
                // Enable the text to inform the player of the key to press to pickup Metal Pipe
                pickupPipe.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Add Metal Pipe to inventory
                    playerInventory.addShipPart(Player_Inventory.ShipPart.Pipe);
                    pickupPipe.enabled = false;
                    Destroy(other.gameObject);
                }
            }
        }
        // Check if the player is standing over the Spanner pickup item
        if (other.gameObject.tag == "Spanner")
        {
            if (playerInventory.getShipPartAmount(Player_Inventory.ShipPart.Spanner) < 1)
            {
                // Enable the text to inform the player of the key to press to pickup Spanner
                pickupSpanner.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Add Spanner to inventory
                    playerInventory.addShipPart(Player_Inventory.ShipPart.Spanner);
                    pickupSpanner.enabled = false;
                    Destroy(other.gameObject);
                }
            }
        }
        // Check if the player is standing over the Spring pickup item
        if (other.gameObject.tag == "Spring")
        {
            if (playerInventory.getShipPartAmount(Player_Inventory.ShipPart.Spring) < 1)
            {
                // Enable the text to inform the player of the key to press to pickup Spring
                pickupSpring.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // If player picks up the Spring | Add Spring to inventory
                    playerInventory.addShipPart(Player_Inventory.ShipPart.Spring);
                    pickupSpring.enabled = false;
                    Destroy(other.gameObject);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Enable top mesh when player exits the ship or leaves a building
        if (other.gameObject.tag == "Ship" || other.gameObject.tag == "Building")
        {
            other.GetComponent<MeshRenderer>().enabled = true;
        }
        // Disable pickup text if player leaves food proximity
        if (other.gameObject.tag == "Food")
        {
            pickupFood.enabled = false;
            invFoodFull.enabled = false;
        }
        // Disable pickup text if player leaves powercell proximity
        if (other.gameObject.tag == "PowerCell")
        {
            pickupPowerCell.enabled = false;
            invPowerFull.enabled = false;
        }
        // Disable pickup text if player leaves oxygen tank proximity
        if (other.gameObject.tag == "OxygenTank")
        {
            pickupOxygenTank.enabled = false;
            invOxygenFull.enabled = false;
        }
        // Disable pickup text if player leaves fire extinguisher proximity
        if (other.gameObject.tag == "Extinguisher")
        {
            pickupFireExt.enabled = false;
            invExtFull.enabled = false;
        }
        // Disable pickup text if player leaves Hammer proximity
        if (other.gameObject.tag == "Hammer")
        {
            pickupHammer.enabled = false;
            invHammerFull.enabled = false;
        }
        // Disable pickup text if player leaves Metal Pipe proximity
        if (other.gameObject.tag == "Metal Pipe")
        {
            pickupPipe.enabled = false;
            invPipeFull.enabled = false;
        }
        // Disable pickup text if player leaves Spanner proximity
        if (other.gameObject.tag == "Spanner")
        {
            pickupSpanner.enabled = false;
            invSpannerFull.enabled = false;
        }
        // Disable pickup text if player leaves Spring proximity
        if (other.gameObject.tag == "Spring")
        {
            pickupSpring.enabled = false;
            invSpringFull.enabled = false;
        }
    }
}
