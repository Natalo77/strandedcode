using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : Singleton<GameStateController> {

    private GameObject spawn;

	// Use this for initialization
	void Start () {
        spawn = GameObject.FindGameObjectWithTag("Spawn");
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name.Equals("Level"))
        {
            TESTFUNCTION_dropPlayer();
        }
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
    }

    public void endGame()
    {
        Debug.Log("Loading Main Menu");
        SceneManager.LoadScene("Main Menu");
    }
    
    public void startGame()
    {
        Debug.Log("Loading main game scene");
        SceneManager.LoadScene/**("GeneratorTest");**/("Level");
    }

    public void beginGen()
    {
        this.gameObject.AddComponent<Generator_Sys>();
    }

    public void TESTFUNCTION_dropPlayer()
    {
        Debug.Log("Spawning Player");
        GameObject.Instantiate(GetComponent<BuildingPrefabWrapper>().player, spawn.transform.position, Quaternion.Euler(0, 0, 0));
    }
}
