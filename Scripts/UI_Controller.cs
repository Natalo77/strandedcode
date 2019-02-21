using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour {

    public Text pickupFood, pickupPowerCell, pickupOxygenTank;
    public Text pickupFireExt, pickupHammer, pickupPipe, pickupSpanner, pickupSpring;

    // Use this for initialization
    void Start () {
        // Disable all pickup texts upon starting the game
        pickupFood.enabled = false;
        pickupPowerCell.enabled = false;
        pickupOxygenTank.enabled = false;

        pickupFireExt.enabled = false;
        pickupHammer.enabled = false;
        pickupPipe.enabled = false;
        pickupSpanner.enabled = false;
        pickupSpring.enabled = false;
	}
}
