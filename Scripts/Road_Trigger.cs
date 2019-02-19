using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Trigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("A");
        if (!GetComponentInParent<Road_Info>().usedByGenerator && other.gameObject.tag == "Player")
        {
            GameStateController.Instance.GetComponent<Generator_Sys>().generate(GetComponentInParent<Road_Info>().location);
            GetComponentInParent<Road_Info>().hasBeenUsed();
        }
    }
}
