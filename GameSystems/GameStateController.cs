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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            beginGen();
        }
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            TESTFUNCTION_dropPlayer();
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
        SceneManager.LoadScene("GeneratorTest");//"main");
    }

    public void beginGen()
    {
        this.gameObject.AddComponent<Generator_Sys>();
    }

    public void TESTFUNCTION_dropPlayer()
    {
        GameObject.Instantiate(GetComponent<BuildingPrefabWrapper>().player, new Vector3(25, 5, 0), Quaternion.Euler(0,0,0));
    }
}
