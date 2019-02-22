using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour {

    public enum Pickups { Food, Oxygen, Power};
    public enum ShipPart { Extinguisher, Hammer, Pipe, Spanner, Spring};

    //Food, Oxygen, Power.
    private int[] pickups = new int[3] { 0, 0, 0 };

    //Extinguisher, Hammer, Pipe, Spanner, Spring.
    private int[] shipParts = new int[5] { 0, 0, 0, 0, 0 };

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public bool getHasPickup(Pickups pickupType)
    {
        return pickups[(int)pickupType] >= 1;
    }

    public bool getHasShipPart(ShipPart shipPart)
    {
        return shipParts[(int)shipPart] >= 1;
    }

    public void addPickup(Pickups pickupType)
    {
        pickups[(int)pickupType]++;
    }

    public void addShipPart(ShipPart shipPart)
    {
        shipParts[(int)shipPart]++;
    }

    public void usePickup(Pickups pickupType)
    {
        if(pickups[(int)pickupType] >= 1)
        {
            pickups[(int)pickupType]--;
        }
    }

    public void useShipPart(ShipPart shipPart)
    {
        if(shipParts[(int)shipPart] >= 1)
        {
            shipParts[(int)shipPart]--;
        }
    }

    public int getPickupAmount(Pickups pickupType)
    {
        return pickups[(int)pickupType];
    }

    public int getShipPartAmount(ShipPart shipPartType)
    {
        return shipParts[(int)shipPartType];
    }
}
