using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : Singleton<GameStateController> {

    private GameObject spawn;
    public bool playerSpawned;

	// Use this for initialization
	void Start () {
        playerSpawned = false;
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 1)
        {
        StartCoroutine(beginGen());
        Debug.Log("Gen Returned");

        spawn = GameObject.FindGameObjectWithTag("Spawn");
        TESTFUNCTION_dropPlayer();
        }

    }


    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        //Debug.Log(mode);

        


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

    public IEnumerator beginGen()
    {
        Debug.Log("GenStarted");
        this.gameObject.AddComponent<Generator_Sys>();


        yield return true;
    }

    public void TESTFUNCTION_dropPlayer()
    {
        Debug.Log("Spawning Player");
        GameObject.Instantiate(GetComponent<BuildingPrefabWrapper>().player, spawn.transform.position, Quaternion.Euler(0, 0, 0));
        playerSpawned = true;
    }
}
