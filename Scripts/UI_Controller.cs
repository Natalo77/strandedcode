using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour {

    public Text pickupFood, pickupPowerCell, pickupOxygenTank;
    public Text pickupFireExt, pickupHammer, pickupPipe, pickupSpanner, pickupSpring;
    public Text invFoodFull, invPowerFull, invOxygenFull;
    public Text invExtFull, invHammerFull, invPipeFull, invSpannerFull, invSpringFull;
    public Text fixEngine, fixLifeSupport, fixReactor, fixControls, fixBattery;
    public Text reqExt, reqHammer, reqPipe, reqSpanner, reqSpring;
    public Text engineFixed, lifeSupportFixed, reactorFixed, controlsFixed, batteryFixed;

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

        invFoodFull.enabled = false;
        invPowerFull.enabled = false;
        invOxygenFull.enabled = false;

        invExtFull.enabled = false;
        invHammerFull.enabled = false;
        invPipeFull.enabled = false;
        invSpannerFull.enabled = false;
        invSpringFull.enabled = false;

        fixEngine.enabled = false;
        fixLifeSupport.enabled = false;
        fixReactor.enabled = false;
        fixControls.enabled = false;
        fixBattery.enabled = false;

        reqExt.enabled = false;
        reqHammer.enabled = false;
        reqPipe.enabled = false;
        reqSpanner.enabled = false;
        reqSpring.enabled = false;

        engineFixed.enabled = false;
        lifeSupportFixed.enabled = false;
        reactorFixed.enabled = false;
        controlsFixed.enabled = false;
        batteryFixed.enabled = false;
	}
}
