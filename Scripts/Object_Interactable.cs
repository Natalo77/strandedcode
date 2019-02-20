
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object_Interactable : MonoBehaviour
{
    public Transform other; // interactable object
    private Player_Needs playerNeeds; // will be needed to call some variable from Player_Needs

    public GameObject showText;
    public GameObject showText1; // for tutorial purpose

    GameObject targetTag;
    GameObject player;
    Player_Needs refillNeed;
    TargetIndicator targetIndicator;

    private void Start()
    {
        targetTag = GameObject.FindWithTag("Target");
        player = GameObject.FindWithTag("Player");
        refillNeed = player.GetComponent<Player_Needs>();
        targetIndicator = GetComponent<TargetIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        refillNeed = player.GetComponent<Player_Needs>();
        if (other)
        {
            float dist = Vector3.Distance(other.position, transform.position);
            if (dist < targetIndicator.m_effectiveDistance)
            {
                showText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    refillNeed.playerCurrentO2 = 100.2f;
                    // for Tutorial purpose
                    showText1.SetActive(true);
                }
            }
            if (dist > targetIndicator.m_effectiveDistance)
            {
                // Disable text when out of range
                showText.SetActive(false);
                if (Input.GetKeyDown(KeyCode.N))
                {
                    showText1.SetActive(false);
                }
            }
        }
    }

   /* public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") targetIndicator.gameObject.GetComponent<Renderer>().enabled = false;
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") targetIndicator.gameObject.GetComponent<Renderer>().enabled = true;
    }*/
}
