using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : Singleton<GameStateController> {



	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.G))
        {
            startGame();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            endGame();
        }
    }

    public void endGame()
    {
        Debug.Log("Loading Main Menu");
        SceneManager.LoadScene("Main Menu");
    }
    
    public void startGame()
    {
        Debug.Log("Loading main game scene");
        SceneManager.LoadScene("main");
    }
}
