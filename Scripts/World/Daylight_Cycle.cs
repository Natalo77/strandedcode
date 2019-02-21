using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daylight_Cycle : MonoBehaviour {

    public float worldTimeInSeconds;
    public float time;
    public float deltaTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(Vector3.zero, Vector3.right, Time.deltaTime * time);
        transform.LookAt(Vector3.zero);

        worldTimeInSeconds += Time.deltaTime;
	}
}
