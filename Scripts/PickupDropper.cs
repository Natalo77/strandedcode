using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDropper : MonoBehaviour {

    public GameObject[] pickups;
    private bool itemIsThere;
    private int randomIndex;
    private int range;

    public bool getItemIsThere()
    {
        return this.itemIsThere;
    }

    public void setItemIsThere(bool itemIsThere)
    {
        this.itemIsThere = itemIsThere;
    }

	// Use this for initialization
	void Start ()
    {
        range = Random.Range(0, 1);
        Debug.Log(range);

        // Spawn pickup prefabs if they are there
        if (range == 1)
        {
            randomIndex = Random.Range(0, 3);
            // Spawn random pickup prefab from array
            GameObject newPickup = Instantiate(pickups[randomIndex], gameObject.transform.position, Quaternion.identity);
            newPickup.transform.parent = gameObject.transform;
            Debug.Log("Spawning " + pickups[randomIndex]);
        }
	}
}
