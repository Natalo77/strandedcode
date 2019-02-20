using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_HUD : MonoBehaviour {
    
    //Text Update stuff for testing purpose on Player HUD
    public Text textUpdateHP;
    public Text textUpdateO2;
    public Text textUpdateHunger;
    
    Player_Needs pNeeds; // will be needed to call some variable from Player_Needs

    private void Start() 
    {
        pNeeds = GetComponent<Player_Needs>();
    }

    // Update is called once per frame
    void Update ()
    {
        UpdateText();
        if (pNeeds)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                gameObject.GetComponent<Canvas>().enabled = !gameObject.GetComponent<Canvas>().enabled;
            }
        }
        

    }

    //Update Text on HUD
    public void UpdateText()
    {
        textUpdateO2.text = "O2: " + pNeeds.playerO2Int;
        textUpdateHunger.text = "Hunger: " + pNeeds.playerHungerInt;
        textUpdateHP.text = "HP: " + pNeeds.playerHPInt;
    }

}
