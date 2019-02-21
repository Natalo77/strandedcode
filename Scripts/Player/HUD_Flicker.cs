using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Flicker : MonoBehaviour {

    private System.Random rand;
    private Player_HUD hud;

    private bool stop;

    private void Start()
    {
        rand = new System.Random();
        hud = gameObject.GetComponent<Player_HUD>();
        stop = false;
    }

    // Update is called once per frame
    void Update () {
        if (!stop)
        {
            if (rand.Next(0, 10) == 1)
            {
                hud.setHUDIsOn(!hud.isHUDOn());
            }
        }
	}

    public void OnEnable()
    {
        this.stop = false;
    }

    public void exit()
    {
        stop = true;
        hud.setHUDIsOn(true);
        this.enabled = false;
    }
}
