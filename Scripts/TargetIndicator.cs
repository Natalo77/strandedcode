﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TargetIndicator : MonoBehaviour
{
    private Camera mainCamera;
    private RectTransform m_icon;
    private Image m_iconImage;
    private Canvas mainCanvas;
    private Vector3 m_cameraOffsetUp;
    private Vector3 m_cameraOffsetRight;
    private Vector3 m_cameraOffsetForward;
    private Transform player;
    public Sprite m_targetIconOnScreen;
    public Sprite m_targetIconOffScreen;
    [Space]
    [Range(0, 100)]
    public float m_edgeBuffer;
    public Vector3 m_targetIconScale;
    [Range(0, 100)]
    public float m_effectiveDistance;
    [Space]
    public bool PointTarget = true;
    public bool ShowDebugLines;
    //Indicates if the object is out of the screen
    private bool m_outOfScreen;
    private IEnumerator coroutine;
    private float update;

    GameObject playa;


    void Start()
    {
        playa = GameObject.FindWithTag("Player");
        player = playa.gameObject.transform;
        mainCamera = Camera.main;
        Debug.Assert((mainCamera != null), "There needs to be a Camera object in the scene for the OTI to display");
        mainCanvas = FindObjectOfType<Canvas>();
        Debug.Assert((mainCanvas != null), "There needs to be a Canvas object in the scene for the OTI to display");
        InstainateTargetIcon();
    }

    void Update()
    {
        if (ShowDebugLines)
            DrawDebugLines();
        UpdateTargetIconPosition();

        // when player near the target will be disabled and when the player press N it will activate again.
        if (player)
        {
            float dist = Vector3.Distance(player.position, transform.position);
            if (dist < m_effectiveDistance)
            {
                m_iconImage.gameObject.GetComponent<Image>().enabled = false;
            }
            else
            {
                m_iconImage.gameObject.GetComponent<Image>().enabled = true;
            }
            /*else if (Input.GetKeyDown(KeyCode.N)) //for Tutorial purpose
            {
                m_iconImage.gameObject.GetComponent<Image>().enabled = !m_iconImage.gameObject.GetComponent<Image>().enabled;
            }
            else if (Input.GetKeyDown(KeyCode.M)) //for Tutorial purpose
            {
                m_iconImage.gameObject.GetComponent<Image>().enabled = false;
            }*/
        }
    }

    private void InstainateTargetIcon()
    {
        m_icon = new GameObject().AddComponent<RectTransform>();
        m_icon.transform.SetParent(mainCanvas.transform);
        m_icon.localScale = m_targetIconScale;
        m_icon.name = name + ": OTI icon";
        m_icon.tag = "Target";
        m_iconImage = m_icon.gameObject.AddComponent<Image>();
        m_iconImage.sprite = m_targetIconOnScreen;
    }
    private void UpdateTargetIconPosition()
    {
        Vector3 newPos = transform.position;
        newPos = mainCamera.WorldToViewportPoint(newPos);
        //Simple check if the target object is out of the screen or inside
        if (newPos.x > 1 || newPos.y > 1 || newPos.x < 0 || newPos.y < 0)
            m_outOfScreen = true;
        else
            m_outOfScreen = false;
        if (newPos.z < 0)
        {
            newPos.x = 1f - newPos.x;
            newPos.y = 1f - newPos.y;
            newPos.z = 0;
            newPos = Vector3Maxamize(newPos);
        }
        newPos = mainCamera.ViewportToScreenPoint(newPos);
        newPos.x = Mathf.Clamp(newPos.x, m_edgeBuffer, Screen.width - m_edgeBuffer);
        newPos.y = Mathf.Clamp(newPos.y, m_edgeBuffer, Screen.height - m_edgeBuffer);
        m_icon.transform.position = newPos;
        //Operations if the object is out of the screen
        if (m_outOfScreen)
        {
            //Show the target off screen icon
            m_iconImage.sprite = m_targetIconOffScreen;
            if (PointTarget)
            {
                //Rotate the sprite towards the target object
                var targetPosLocal = mainCamera.transform.InverseTransformPoint(transform.position);
                var targetAngle = -Mathf.Atan2(targetPosLocal.x, targetPosLocal.y) * Mathf.Rad2Deg - 90;
                //Apply rotation
                m_icon.transform.eulerAngles = new Vector3(0, 0, targetAngle);
            }

        }
        else
        {
            //Reset rotation to zero and swap the sprite to the "on screen" one
            m_icon.transform.eulerAngles = new Vector3(0, 0, 0);
            m_iconImage.sprite = m_targetIconOnScreen;
        }
        

    }

    public void DrawDebugLines()
    {
        Vector3 directionFromCamera = transform.position - mainCamera.transform.position;
        Vector3 cameraForwad = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;
        Vector3 cameraUp = mainCamera.transform.up;
        cameraForwad *= Vector3.Dot(cameraForwad, directionFromCamera);
        cameraRight *= Vector3.Dot(cameraRight, directionFromCamera);
        cameraUp *= Vector3.Dot(cameraUp, directionFromCamera);
        Debug.DrawRay(mainCamera.transform.position, directionFromCamera, Color.magenta);
        Vector3 forwardPlaneCenter = mainCamera.transform.position + cameraForwad;
        Debug.DrawLine(mainCamera.transform.position, forwardPlaneCenter, Color.blue);
        Debug.DrawLine(forwardPlaneCenter, forwardPlaneCenter + cameraUp, Color.green);
        Debug.DrawLine(forwardPlaneCenter, forwardPlaneCenter + cameraRight, Color.red);
    }
    public Vector3 Vector3Maxamize(Vector3 vector)
    {
        Vector3 returnVector = vector;
        float max = 0;
        max = vector.x > max ? vector.x : max;
        max = vector.y > max ? vector.y : max;
        max = vector.z > max ? vector.z : max;
        returnVector /= max;
        return returnVector;
    }

    private void OnDrawGizmosSelected()
    {
        // Display the radius when selected
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, m_effectiveDistance);
    }

    public void SpawnW8Test()
    {
        if (GameStateController.Instance.playerSpawned)
        {
            //Debug.Log(GameStateController.Instance.playerSpawned);
            UpdateTargetIconPosition();
            
        }
    }
    public void ActivateThisObject()
    {
        this.gameObject.SetActive(true);
    }
}