using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDropper : MonoBehaviour {

    // Array of pickups
    public GameObject[] pickups;

    private int randomIndex;
    private int willSpawn;

    // Values to check amount of spawned pickups
    private int food;
    private int oxygenTank;
    private int powerCell;

	// Use this for initialization
	void Start ()
    {
        // Choose whether to spawn pickups or not | 0 being false and 1 being true
        willSpawn = Random.Range(0, 2);

        // If pickup item should spawn
        if (willSpawn == 1)
        {
            // Choose random prefab from array
            randomIndex = Random.Range(0, pickups.Length);

            // Spawn random pickup prefab from array
            GameObject newPickup = Instantiate(pickups[randomIndex], gameObject.transform.position, Quaternion.identity);
            newPickup.transform.parent = gameObject.transform;
        }
	}
}
