using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Interaction : MonoBehaviour {

    private UI_Controller uiController;
    private Text pickupFood, pickupPowerCell, pickupOxygenTank;
    private Text pickupFireExt, pickupHammer, pickupPipe, pickupSpanner, pickupSpring;

    private void Start()
    {
        // Reference to the UI_Controller script
        uiController = GameObject.Find("UI_Controller").GetComponent<UI_Controller>();
        // Setting the pickup item text objects
        pickupFood = uiController.pickupFood;
        pickupOxygenTank = uiController.pickupOxygenTank;
        pickupPowerCell = uiController.pickupPowerCell;

        pickupFireExt = uiController.pickupFireExt;
        pickupHammer = uiController.pickupHammer;
        pickupPipe = uiController.pickupPipe;
        pickupSpanner = uiController.pickupSpanner;
        pickupSpring = uiController.pickupSpring;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Disable top mesh if player enters the ship or a building
        if (other.gameObject.tag == "Ship" || other.gameObject.tag == "Building")
        {
            other.GetComponent<MeshRenderer>().enabled = false;
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
            // Enable the text to inform the player of the key to press to pickup food
            pickupFood.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                // If player picks up the food | Add food to inventory
                gameObject.GetComponent<Player_Needs>().playerCurrentHunger += 25.0f;
                pickupFood.enabled = false;
                Destroy(other.gameObject);
            }
        }
        // Check if the player is standing over the PowerCell pickup item
        if (other.gameObject.tag == "PowerCell")
        {
            // Enable the text to inform the player of the key to press to pickup powercell
            pickupPowerCell.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                // If player picks up the powercell | Add powercell to inventory
                gameObject.GetComponent<Player_Needs>().playerCurrentPower += 25.0f;
                pickupPowerCell.enabled = false;
                Destroy(other.gameObject);
            }
        }
        // Check if the player is standing over the OxygenTank pickup item
        if (other.gameObject.tag == "OxygenTank")
        {
            // Enable the text to inform the player of the key to press to pickup oxygen tank
            pickupOxygenTank.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                // If player picks up the oxygen tank | Add oxygen tank to inventory
                gameObject.GetComponent<Player_Needs>().playerCurrentO2 += 25.0f;
                pickupOxygenTank.enabled = false;
                Destroy(other.gameObject);
            }
        }
        // Check if the player is standing over the fire Extinguisher pickup item
        if (other.gameObject.tag == "Extinguisher")
        {
            // Enable the text to inform the player of the key to press to pickup fire extinguisher
            pickupFireExt.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                // If player picks up the fire extinguisher | Add fire extinguisher to inventory
                pickupFireExt.enabled = false;
                Destroy(other.gameObject);
            }
        }
        // Check if the player is standing over the Hammer pickup item
        if (other.gameObject.tag == "Hammer")
        {
            // Enable the text to inform the player of the key to press to pickup Hammer
            pickupHammer.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                // If player picks up the Hammer | Add Hammer to inventory
                pickupHammer.enabled = false;
                Destroy(other.gameObject);
            }
        }
        // Check if the player is standing over the Metal Pipe pickup item
        if (other.gameObject.tag == "Metal Pipe")
        {
            // Enable the text to inform the player of the key to press to pickup Metal Pipe
            pickupPipe.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                // If player picks up the Metal Pipe | Add Metal Pipe to inventory
                pickupPipe.enabled = false;
                Destroy(other.gameObject);
            }
        }
        // Check if the player is standing over the Spanner pickup item
        if (other.gameObject.tag == "Spanner")
        {
            // Enable the text to inform the player of the key to press to pickup Spanner
            pickupSpanner.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                // If player picks up the Spanner | Add Spanner to inventory
                pickupSpanner.enabled = false;
                Destroy(other.gameObject);
            }
        }
        // Check if the player is standing over the Spring pickup item
        if (other.gameObject.tag == "Spring")
        {
            // Enable the text to inform the player of the key to press to pickup Spring
            pickupSpring.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                // If player picks up the Spring | Add Spring to inventory
                pickupSpring.enabled = false;
                Destroy(other.gameObject);
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
        }
        // Disable pickup text if player leaves powercell proximity
        if (other.gameObject.tag == "PowerCell")
        {
            pickupPowerCell.enabled = false;
        }
        // Disable pickup text if player leaves oxygen tank proximity
        if (other.gameObject.tag == "OxygenTank")
        {
            pickupOxygenTank.enabled = false;
        }
        // Disable pickup text if player leaves fire extinguisher proximity
        if (other.gameObject.tag == "Extinguisher")
        {
            pickupFireExt.enabled = false;
        }
        // Disable pickup text if player leaves Hammer proximity
        if (other.gameObject.tag == "Hammer")
        {
            pickupHammer.enabled = false;
        }
        // Disable pickup text if player leaves Metal Pipe proximity
        if (other.gameObject.tag == "Metal Pipe")
        {
            pickupPipe.enabled = false;
        }
        // Disable pickup text if player leaves Spanner proximity
        if (other.gameObject.tag == "Spanner")
        {
            pickupSpanner.enabled = false;
        }
        // Disable pickup text if player leaves Spring proximity
        if (other.gameObject.tag == "Spring")
        {
            pickupSpring.enabled = false;
        }
    }
}
