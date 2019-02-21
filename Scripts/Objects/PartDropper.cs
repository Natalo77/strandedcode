using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartDropper : MonoBehaviour
{
    // Array of parts
    public GameObject[] parts;

    private int randomIndex;
    private int range;
    public int maxObjects;
    
    // Values to check amount of spawned parts
    private int ext;
    private int hammer;
    private int pipe;
    private int spanner;
    private int spring;

    // Use this for initialization
    void Start()
    {
        // Check amount of parts currently placed in the scene
        ext = GameObject.FindGameObjectsWithTag("Extinguisher").Length;
        hammer = GameObject.FindGameObjectsWithTag("Hammer").Length;
        pipe = GameObject.FindGameObjectsWithTag("Metal Pipe").Length;
        spanner = GameObject.FindGameObjectsWithTag("Spanner").Length;
        spring = GameObject.FindGameObjectsWithTag("Spring").Length;

        // If 2 or more parts have spawned then replace the part prefab with null in the array
        if (ext >= maxObjects)
        {
            parts[0] = null;
        }
        if (hammer >= maxObjects)
        {
            parts[1] = null;
        }
        if (pipe >= maxObjects)
        {
            parts[2] = null;
        }
        if (spanner >= maxObjects)
        {
            parts[3] = null;
        }
        if (spring >= maxObjects)
        {
            parts[4] = null;
        }

        // Choose whether the parts will spawn or now | 0 being false and 1 being true
        range = Random.Range(0, 2);

        // If part should spawn
        if(range == 1)
        {
            // Choose random prefab from array
            randomIndex = Random.Range(0, parts.Length);

            // If that part is still available to be placed
            if (parts[randomIndex] != null)
            {
                // Spawn the part
                GameObject newPickup = Instantiate(parts[randomIndex], gameObject.transform.position, Quaternion.identity);
                newPickup.transform.parent = gameObject.transform;

                // Re-evalulate the amount of spawned parts
                ext = GameObject.FindGameObjectsWithTag("Extinguisher").Length;
                hammer = GameObject.FindGameObjectsWithTag("Hammer").Length;
                pipe = GameObject.FindGameObjectsWithTag("Metal Pipe").Length;
                spanner = GameObject.FindGameObjectsWithTag("Spanner").Length;
                spring = GameObject.FindGameObjectsWithTag("Spring").Length;
            }
        }
    }
}