﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartDropper : MonoBehaviour
{
    public GameObject[] parts;
    public System.Collections.Generic.List<GameObject> list;
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
        list = new System.Collections.Generic.List<GameObject>(parts);
        // Choose whether the parts will spawn or now | 0 being false and 1 being true
        range = Random.Range(0, 2);

        // If part should spawn
        if(range == 1)
        {
            // Choose random prefab from array
            randomIndex = Random.Range(0, parts.Length);

            GameObject newPickup = Instantiate(list[randomIndex], gameObject.transform.position, Quaternion.identity);
            newPickup.transform.parent = gameObject.transform;
            Debug.Log("Spawning " + list[randomIndex]);

            ext = GameObject.FindGameObjectsWithTag("Extinguisher").Length;
            hammer = GameObject.FindGameObjectsWithTag("Hammer").Length;
            pipe = GameObject.FindGameObjectsWithTag("Metal Pipe").Length;
            spanner = GameObject.FindGameObjectsWithTag("Spanner").Length;
            spring = GameObject.FindGameObjectsWithTag("Spring").Length;

            Debug.Log("Ext amount = " + ext);
            Debug.Log("Hammer amount = " + hammer);
            Debug.Log("Pipe amount = " + pipe);
            Debug.Log("Spanner amount = " + spanner);
            Debug.Log("Spring amount = " + spring);

            Debug.Log(list);
        }
    }

    private void Update()
    {
        ext = GameObject.FindGameObjectsWithTag("Extinguisher").Length;
        hammer = GameObject.FindGameObjectsWithTag("Hammer").Length;
        pipe = GameObject.FindGameObjectsWithTag("Metal Pipe").Length;
        spanner = GameObject.FindGameObjectsWithTag("Spanner").Length;
        spring = GameObject.FindGameObjectsWithTag("Spring").Length;

        if(ext >= 2)
        {
            Debug.Log("If statement was called");
        }
    }
}