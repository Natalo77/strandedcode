﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadNode{

    public enum EndType { Closed, Straight, T, Four};

    /**
     * UP: true
     * {
     *          endTop
     *            N
     *            |
     *    BlockNW | BlockES
     *            |
     *            S
     *         endBottom
     * }
     *      
     * UP: false
     * {
     *              blockNW
     *  endBottom S---------N EndTop
     *              blockES
     * 
     * }
     */ 

    private bool up;
    private GameObject blockNW;
    private GameObject blockES;
    private EndType endTop;
    private EndType endBottom;
    private Vector2 location;

    private int angle;

    /**
     * Creates a RoadNode with the specified information.
     */
    public RoadNode(bool up, GameObject NW, GameObject ES, EndType top, EndType bottom, Vector2 location)
    {
        this.up = up;
        blockNW = NW;
        blockES = ES;
        endTop = top;
        endBottom = bottom;
        this.location = location;

        if(this.up)
        {
            this.angle = 0;
        }
        else
        {
            this.angle = 90;
        }

        GameObject road = GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().road;
        road.GetComponent<Road_Info>().setLocation((int)location.x, (int)location.y);
        road.GetComponent<Road_Info>().setUsed(false);

        GameObject.Instantiate(road, new Vector3((int)(location.x * 2.5f * 10.0f), 0.0f, (int)(location.y * 2.5f * 10.0f)), Quaternion.Euler(new Vector3(0, (int)angle, 0)), null);
    }

    public RoadNode(bool up, GameObject NW, GameObject ES, EndType top, EndType bottom, Vector2 location, bool used)
    {
        this.up = up;
        blockNW = NW;
        blockES = ES;
        endTop = top;
        endBottom = bottom;
        this.location = location;

        if (this.up)
        {
            this.angle = 0;
        }
        else
        {
            this.angle = 90;
        }

        GameObject road = GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().road;
        road.GetComponent<Road_Info>().setLocation((int)location.x, (int)location.y);
        road.GetComponent<Road_Info>().setUsed(used);

        GameObject.Instantiate(GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().road, new Vector3((int)(location.x * 2.5f * 10.0f), 0.0f, (int)(location.y * 2.5f * 10.0f)), Quaternion.Euler(new Vector3(0, (int)angle, 0)), null);

    }

    public bool getUp()
    {
        return this.up;
    }

    public GameObject getblockNW()
    {
        return this.blockNW;
    }

    public GameObject getblockES()
    {
        return this.blockES;
    }

    public EndType getTop()
    {
        return this.endTop;
    }

    public EndType getBottom()
    {
        return this.endBottom;
    }

    public Vector2 getLocation()
    {
        return this.location;
    }
}
