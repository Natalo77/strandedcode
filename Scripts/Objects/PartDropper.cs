using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartDropper : MonoBehaviour
{
    //public System.Collections.Generic.List<GameObject> list;
    public GameObject[] parts;

    //public GameObject extinguisher;
    private int randomIndex;
    private int range;

    public int ext;
    public int hammer;
    public int pipe;
    public int spanner;
    public int spring;

    // Use this for initialization
    void Start()
    {
        if (ext >= 2)
        {
            parts[0] = null;
        }
        if (hammer >= 2)
        {
            parts[1] = null;
        }
        if (pipe >= 2)
        {
            parts[2] = null;
        }
        if (spanner >= 2)
        {
            parts[3] = null;
        }
        if (spring >= 2)
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
            Debug.Log("index = " + randomIndex);

            if (parts[randomIndex] != null)
            {
                GameObject newPickup = Instantiate(parts[randomIndex], gameObject.transform.position, Quaternion.identity);
                newPickup.transform.parent = gameObject.transform;
                Debug.Log("Spawning " + newPickup);
            }

            ext = GameObject.FindGameObjectsWithTag("Extinguisher").Length;
            hammer = GameObject.FindGameObjectsWithTag("Hammer").Length;
            pipe = GameObject.FindGameObjectsWithTag("Metal Pipe").Length;
            spanner = GameObject.FindGameObjectsWithTag("Spanner").Length;
            spring = GameObject.FindGameObjectsWithTag("Spring").Length;
        }
    }

    private void Update()
    {
        ext = GameObject.FindGameObjectsWithTag("Extinguisher").Length;
        hammer = GameObject.FindGameObjectsWithTag("Hammer").Length;
        pipe = GameObject.FindGameObjectsWithTag("Metal Pipe").Length;
        spanner = GameObject.FindGameObjectsWithTag("Spanner").Length;
        spring = GameObject.FindGameObjectsWithTag("Spring").Length;
    }
}