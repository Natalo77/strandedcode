using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_HUD : MonoBehaviour
{

    //Text Update stuff for testing purpose on Player HUD
    public Text textUpdateHP;
    public Text textUpdateO2;
    public Text textUpdateHunger;
    private Canvas mainCanvas;
    private Transform canvasChild;

    private bool toggleBool;

    Player_Needs pNeeds; // will be needed to call some variable from Player_Needs

    void Start()
    {
        
        pNeeds = GetComponent<Player_Needs>();
        canvasChild = transform.Find("Canvas");
        CanvasKun();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();

        if (pNeeds)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                canvasChild.gameObject.GetComponent<Canvas>().enabled = !canvasChild.gameObject.GetComponent<Canvas>().enabled;
                SoundManager.instance.PlaySingle(SoundManager.instance.hudSound);
                Debug.Log("Canvas toggle activated");
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

    public void CanvasKun()
    {
        if (GameStateController.Instance.playerSpawned == true)
        {
            Debug.Log(GameStateController.Instance.playerSpawned);
            canvasChild.transform.SetParent(mainCanvas.transform);
        }
    }
}
