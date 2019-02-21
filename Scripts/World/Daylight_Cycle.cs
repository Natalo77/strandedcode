using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daylight_Cycle : MonoBehaviour {

    public float worldTimeInSeconds;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(Vector3.zero, Vector3.right, 5f * Time.deltaTime);
        transform.LookAt(Vector3.zero);

        worldTimeInSeconds += Time.deltaTime;
	}
}
