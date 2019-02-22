using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerCheck : MonoBehaviour
{
    public GameObject targetPointer;
    private Canvas mainCanvas;
    private Transform canvasChild;
    // Use this for initialization
    void Start()
    {
        if (targetPointer)
        {
            Debug.Log(GameStateController.Instance.playerSpawned);
            targetPointer.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
