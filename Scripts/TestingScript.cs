using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour {

    public GameObject objectToSpawn;
    public Transform spawnPoint;
    public float seconds;

    Coroutine currentCoroutine = null;

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            Debug.Log("Spawning Object! " + Time.time);
            Instantiate(objectToSpawn, spawnPoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(seconds);
        }
    }

    IEnumerator StopAfter (float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        Debug.Log("Stopping current routine");
        StopCoroutine(currentCoroutine);
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Daylight_Cycle test = GameObject.Find("Sun").GetComponent<Daylight_Cycle>();
            Debug.Log(test.worldTimeInSeconds);
        }
	}
}
