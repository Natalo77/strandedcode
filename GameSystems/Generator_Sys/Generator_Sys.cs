using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Generator_Sys : MonoBehaviour {

    private RoadGraph<RoadNode> graph;
    private System.Random rand;

    //Creates the initial Scene point.
    Generator_Sys()
    {
        rand = new System.Random();
        graph = new RoadGraph<RoadNode>();

        //Initialize the initial state.
        //Adjacents.
        graph.add(
            new RoadNode(
                true, 
                GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().home,
                randomSingleBuilding(),
                RoadNode.EndType.Four,
                RoadNode.EndType.Four,
                new Vector2(1,0)
                ));

        graph.add(
            new RoadNode(
                false,
                graph.GetNode(new Vector2(1,0)).getblockNW(),
                randomSingleBuilding(),
                RoadNode.EndType.Four,
                RoadNode.EndType.Four,
                new Vector2(0, -1)
                ));

        graph.add(
            new RoadNode(
                true,
                randomSingleBuilding(),
                graph.GetNode(new Vector2(1,0)).getblockNW(),
                RoadNode.EndType.Four,
                RoadNode.EndType.Four,
                new Vector2(-1, 0)
                ));

        graph.add(
            new RoadNode(
                false,
                randomSingleBuilding(),
                graph.GetNode(new Vector2(1,0)).getblockNW(),
                RoadNode.EndType.Four,
                RoadNode.EndType.Four,
                new Vector2(0, 1)
                ));

        //Verticals
        graph.add(
            new RoadNode(
                true,
                graph.GetNode(new Vector2(0, 1)).getblockNW(),
                randomSingleBuilding(),
                RoadNode.EndType.Four,
                RoadNode.EndType.Four,
                new Vector2(1, 2)
                ));

        graph.add(
            new RoadNode(
                true,
                graph.GetNode(new Vector2(0, -1)).getblockES(),
                randomSingleBuilding(),
                RoadNode.EndType.Four,
                RoadNode.EndType.Four,
                new Vector2(1, -2)
                ));

        graph.add(
            new RoadNode(
                true,
                randomSingleBuilding(),
                graph.GetNode(new Vector2(0, -1)).getblockES(),
                RoadNode.EndType.Four,
                RoadNode.EndType.Four,
                new Vector2(-1, -2)
                ));

        graph.add(
            new RoadNode(
                true,
                randomSingleBuilding(),
                graph.GetNode(new Vector2(0, 1)).getblockNW(),
                RoadNode.EndType.Four,
                RoadNode.EndType.Four,
                new Vector2(-1, 2)
                ));

        //Fill in.
        graph.add(
            new RoadNode(
                false,
                graph.GetNode(new Vector2(1, 2)).getblockES(),
                graph.GetNode(new Vector2(1, 0)).getblockES(),
                RoadNode.EndType.Four,
                RoadNode.EndType.Four,
                new Vector2(2, 1)
                ));

        graph.add(
            new RoadNode(
                false,
                graph.GetNode(new Vector2(1, 0)).getblockES(),
                graph.GetNode(new Vector2(1, -2)).getblockES(),
                RoadNode.EndType.Four,
                RoadNode.EndType.Four,
                new Vector2(1, -1)
                ));

        graph.add(
            new RoadNode(
                false,
                graph.GetNode(new Vector2(-1, 0)).getblockES(),
                graph.GetNode(new Vector2(-1, -2)).getblockES(),
                RoadNode.EndType.Four,
                RoadNode.EndType.Four,
                new Vector2(-2, -1)
                ));

        graph.add(
            new RoadNode(
                false,
                graph.GetNode(new Vector2(-1, 2)).getblockES(),
                graph.GetNode(new Vector2(-1, 0)).getblockES(),
                RoadNode.EndType.Four,
                RoadNode.EndType.Four,
                new Vector2(1, -2)
                ));


        //Edges.
        graph.add(graph.GetNode(new Vector2(0, 1)), graph.GetNode(new Vector2(1, 0)));
        graph.add(graph.GetNode(new Vector2(1, 0)), graph.GetNode(new Vector2(0, 1)));
        graph.add(graph.GetNode(new Vector2(1, 0)), graph.GetNode(new Vector2(0, -1)));
        graph.add(graph.GetNode(new Vector2(0, -1)), graph.GetNode(new Vector2(1, 0)));
        graph.add(graph.GetNode(new Vector2(0, -1)), graph.GetNode(new Vector2(-1, 0)));
        graph.add(graph.GetNode(new Vector2(-1, 0)), graph.GetNode(new Vector2(0, -1)));
        graph.add(graph.GetNode(new Vector2(-1, 0)), graph.GetNode(new Vector2(0, 1)));
        graph.add(graph.GetNode(new Vector2(0, 1)), graph.GetNode(new Vector2(-1, 0)));
        graph.add(graph.GetNode(new Vector2(0, 1)), graph.GetNode(new Vector2(1, 2)));
        graph.add(graph.GetNode(new Vector2(1, 2)), graph.GetNode(new Vector2(0, 1)));
        graph.add(graph.GetNode(new Vector2(1, 2)), graph.GetNode(new Vector2(2, 1)));
        graph.add(graph.GetNode(new Vector2(2, 1)), graph.GetNode(new Vector2(1, 2)));
        graph.add(graph.GetNode(new Vector2(2, 1)), graph.GetNode(new Vector2(1, 0)));
        graph.add(graph.GetNode(new Vector2(1, 0)), graph.GetNode(new Vector2(2, 1)));
        graph.add(graph.GetNode(new Vector2(1, 0)), graph.GetNode(new Vector2(1, -1)));
        graph.add(graph.GetNode(new Vector2(1, -1)), graph.GetNode(new Vector2(1, 0)));
        graph.add(graph.GetNode(new Vector2(1, -1)), graph.GetNode(new Vector2(-1, -2)));
        graph.add(graph.GetNode(new Vector2(-1, -2)), graph.GetNode(new Vector2(1, -1)));
        graph.add(graph.GetNode(new Vector2(-1, -2)), graph.GetNode(new Vector2(0, -1)));
        graph.add(graph.GetNode(new Vector2(0, -1)), graph.GetNode(new Vector2(-1, -2)));
        graph.add(graph.GetNode(new Vector2(0, -1)), graph.GetNode(new Vector2(-1, -2)));
        graph.add(graph.GetNode(new Vector2(-1, -2)), graph.GetNode(new Vector2(0, -1)));
        graph.add(graph.GetNode(new Vector2(-1, -2)), graph.GetNode(new Vector2(-2, -1)));
        graph.add(graph.GetNode(new Vector2(-2, -1)), graph.GetNode(new Vector2(-1, -2)));
        graph.add(graph.GetNode(new Vector2(-2, -1)), graph.GetNode(new Vector2(-1, 0)));
        graph.add(graph.GetNode(new Vector2(-1, 0)), graph.GetNode(new Vector2(-2, -1)));
        graph.add(graph.GetNode(new Vector2(-1, 0)), graph.GetNode(new Vector2(1, -2)));
        graph.add(graph.GetNode(new Vector2(1, -2)), graph.GetNode(new Vector2(-1, 0)));
        graph.add(graph.GetNode(new Vector2(1, -2)), graph.GetNode(new Vector2(-1, 2)));
        graph.add(graph.GetNode(new Vector2(-1, 2)), graph.GetNode(new Vector2(1, -2)));
        graph.add(graph.GetNode(new Vector2(-1, 2)), graph.GetNode(new Vector2(0, 1)));
        graph.add(graph.GetNode(new Vector2(0, 1)), graph.GetNode(new Vector2(-1, 2)));

    }

    //Generate sections according to the location passed in.
    public void generate(Vector2 location)
    {

    }

    //Generate a random Roadnode.
    private RoadNode makeNode()
    {
        return null;
    }

    //Get a random 1x1 building
    private GameObject randomSingleBuilding()
    {
        return GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().buildings[rand.Next(0, 9)];
    }
}
