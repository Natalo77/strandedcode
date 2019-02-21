using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDropper : MonoBehaviour {

    public GameObject[] pickups;
    private int randomIndex;
    private int range;

	// Use this for initialization
	void Start ()
    {
        // Choose whether to spawn pickups or not | 0 being false and 1 being true
        range = Random.Range(0, 2);

        // If pickup item should spawn
        if (range == 1)
        {
            // Choose random prefab from array
            randomIndex = Random.Range(0, pickups.Length);

            // Spawn random pickup prefab from array
            GameObject newPickup = Instantiate(pickups[randomIndex], gameObject.transform.position, Quaternion.identity);
            newPickup.transform.parent = gameObject.transform;
        }
	}
}
