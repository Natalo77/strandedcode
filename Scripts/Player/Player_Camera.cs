using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour {

    Vector3 cameraOrientationVector = new Vector3(1, 0, -2);

    public float crosshairsize;
    public Transform target;
    public float turnSpeed = 5f;

    private Vector3 offsetX;
    private Vector3 offsetY;

	// Use this for initialization
	void Start () {
        offsetX = new Vector3 (10, 0, -2);
        offsetY = new Vector3 (10, 0, -2);
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //offsetX = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * turnSpeed, Vector3.up) * offsetX;
       // offsetY = Quaternion.AngleAxis(Input.GetAxis("Vertical") * turnSpeed, Vector3.right) * offsetY;

        //transform.position = target.position + offsetX;
        transform.LookAt(target);
    }
}
