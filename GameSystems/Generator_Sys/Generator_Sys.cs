using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Generator_Sys : MonoBehaviour  {

    private RoadGraph<RoadNode> graph;
    private System.Random rand;

    //Creates the initial Scene point.
    public void Start()
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
                new Vector2(2, -1)
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
                new Vector2(-2, 1)
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

        //---

        graph.add(graph.GetNode(new Vector2(0, 1)), graph.GetNode(new Vector2(1, 2)));
        graph.add(graph.GetNode(new Vector2(1, 2)), graph.GetNode(new Vector2(0, 1)));

        graph.add(graph.GetNode(new Vector2(1, 2)), graph.GetNode(new Vector2(2, 1)));
        graph.add(graph.GetNode(new Vector2(2, 1)), graph.GetNode(new Vector2(1, 2)));

        graph.add(graph.GetNode(new Vector2(2, 1)), graph.GetNode(new Vector2(1, 0)));
        graph.add(graph.GetNode(new Vector2(1, 0)), graph.GetNode(new Vector2(2, 1)));

        //---

        graph.add(graph.GetNode(new Vector2(1, 0)), graph.GetNode(new Vector2(2, -1)));
        graph.add(graph.GetNode(new Vector2(2, -1)), graph.GetNode(new Vector2(1, 0)));

        graph.add(graph.GetNode(new Vector2(2, -1)), graph.GetNode(new Vector2(1, -2)));
        graph.add(graph.GetNode(new Vector2(1, -2)), graph.GetNode(new Vector2(2, -1)));

        graph.add(graph.GetNode(new Vector2(1, -2)), graph.GetNode(new Vector2(0, -1)));
        graph.add(graph.GetNode(new Vector2(0, -1)), graph.GetNode(new Vector2(1, -2)));

        //---

        graph.add(graph.GetNode(new Vector2(0, -1)), graph.GetNode(new Vector2(-1, -2)));
        graph.add(graph.GetNode(new Vector2(-1, -2)), graph.GetNode(new Vector2(0, -1)));

        graph.add(graph.GetNode(new Vector2(-1, -2)), graph.GetNode(new Vector2(-2, -1)));
        graph.add(graph.GetNode(new Vector2(-2, -1)), graph.GetNode(new Vector2(-1, -2)));

        graph.add(graph.GetNode(new Vector2(-2, -1)), graph.GetNode(new Vector2(-1, 0)));
        graph.add(graph.GetNode(new Vector2(-1, 0)), graph.GetNode(new Vector2(-2, -1)));

        //---

        graph.add(graph.GetNode(new Vector2(-1, 0)), graph.GetNode(new Vector2(-2, 1)));
        graph.add(graph.GetNode(new Vector2(-2, 1)), graph.GetNode(new Vector2(-1, 0)));

        graph.add(graph.GetNode(new Vector2(-2, 1)), graph.GetNode(new Vector2(-1, 2)));
        graph.add(graph.GetNode(new Vector2(-1, 2)), graph.GetNode(new Vector2(-2, 1)));

        graph.add(graph.GetNode(new Vector2(-1, 2)), graph.GetNode(new Vector2(0, 1)));
        graph.add(graph.GetNode(new Vector2(0, 1)), graph.GetNode(new Vector2(-1, 2)));

    }

    //Generate sections according to the location passed in.
    public void generate(Vector2 location)
    {

    }

    private enum BlockContent { Ship, RoadUP, RoadRIGHT, Intersection, TN, TE, TS, TW, TwoWayN, TwoWayE, CnrNE, CnrSE, CnrSW, CnrNW, DeadN, DeadE, DeadS, DeadW, Plaza, Building, Empty, B2x1E, B2x1S, B2x2, BDL, BDR, BUL, BUR, Filled };

    /**
     * generates an actual block in position.
     * 
     * PARAM location : The vector3 of the new block in world space.
     */
    public IEnumerator generateBlock(Vector3 location, Direction direction)
    {
        //Create array of direction types.
        BlockContent[,] block = new BlockContent[7,7];

        /*
         *  0 1 2 3 4 5 6 
         *  - - - - - - - 0  
         *  - b - b - b - 1
         *  - - - - - - - 2
         *  - b - b - b - 3
         *  - - - - - - - 4
         *  - b - b - b - 5
         *  - - - - - - - 6
         *  
         */


        
        //Initialize to empty.
        for (int x = 0; x < 7; x++)
        {
            for (int y = 0; y < 7; y++)
            {
                block[y, x] = BlockContent.Empty;
            }
        }
        
        //Fill Intersections.
        for(int x = 0; x < 7; x += 2)
        {
            for(int y = 0; y < 7; y += 2)
            {
                block[y, x] = BlockContent.Intersection;
            }
        }
        
        //Fill roads.
        for (int x = 0; x < 7; x += 2)
        {
            for(int y = 1; y < 7; y += 2)
            {
                block[y, x] = BlockContent.RoadUP;
            }
        }
        for(int x = 1; x < 7; x += 2)
        {
            for(int y = 0; y < 7; y += 2)
            {
                block[y, x] = BlockContent.RoadRIGHT;
            }
        }

        Debug.Log(direction.ToString());

        //Remove bad road.
        if(direction == Direction.N)
        {
            for(int x = 0; x < 7; x++)
            {
                block[6, x] = BlockContent.Empty;
            }
        }
        else if(direction == Direction.E)
        {
            for(int y = 0; y < 7; y++)
            {
                block[y, 0] = BlockContent.Empty;
            }
        }
        else if(direction == Direction.S)
        {
            for(int x = 0; x < 7; x++)
            {
                block[0, x] = BlockContent.Empty;
            }
        }
        else if(direction == Direction.W)
        {
            for (int y = 0; y < 7; y++)
            {
                block[y, 6] = BlockContent.Empty;
            }
        }

        

        //Fill 1x1 buildings.
        for (int x = 1; x < 7; x += 2)
        {
            for (int y = 1; y < 7; y += 2)
            {
                block[y, x] = BlockContent.Building;
            }
        }

        //If the direction is NONE it's the home tile so override the home tile.
        if (direction == Direction.NONE)
        {
            block[3, 3] = BlockContent.Empty;
        }



        /*
         *  0 1 2 3 4 5 6 
         *  - - - - - - - 0  
         *  - b - b - b - 1
         *  - - - - - - - 2
         *  - b - b - b - 3
         *  - - - - - - - 4
         *  - b - b - b - 5
         *  - - - - - - - 6
         *  
         */


        //Fill 2x1 buildings across.
        for (int x = 1; x <= 3; x += 2)
        {
            for(int y = 1; x <= 3; x += 2)
            {
                //Can I put a 2x1 across here?
                if(block[y, x] == BlockContent.Building && block[y, x + 2] == BlockContent.Building)
                {
                    //Do I want to put a 2x1 across here?
                    if(rand.Next(0, 10) == 9)
                    {
                        //Put a 2x1 across here.
                        block[y, x] = BlockContent.B2x1E;
                        block[y, x + 2] = BlockContent.Filled;

                        //Remove the road between them.
                        block[y, x + 1] = BlockContent.Empty;
                    }
                }
            }
        }
        

        /*
         *  0 1 2 3 4 5 6 
         *  - - - - - - - 0  
         *  - b - b - b - 1
         *  - - - - - - - 2
         *  - b - b - b - 3
         *  - - - - - - - 4
         *  - b - b - b - 5
         *  - - - - - - - 6
         *  
         */

        
        //Fill 2x1 buildings down.
        for (int x = 1; x <= 5; x += 2)
        {
            for (int y = 1; x <= 3; x += 2)
            {
                //Can I put a 2x1 down here?
                if (block[y, x] == BlockContent.Building && block[y + 2, x] == BlockContent.Building)
                {
                    //Do I want to put a 2x1 down here?
                    if (rand.Next(0, 10) == 9)
                    {
                        //Put a 2x1 across here.
                        block[y, x] = BlockContent.B2x1S;
                        block[y + 2, x] = BlockContent.Filled;

                        //Remove the road between them.
                        block[y + 1, x] = BlockContent.Empty;
                    }
                }
            }
        }
        
        
        //Fill 2x2 buildings.
        for(int x = 1; x <= 3; x+=2)
        {
            for(int y = 1; y <= 3; y+=2)
            {
                //Can i put a 2x2 down here?
                if(block[y,x] == BlockContent.Building && block[y+2,x] == BlockContent.Building && block[y,x+2] == BlockContent.Building && block[y+2,x+2] == BlockContent.Building)
                {
                    //Do I want to put a 2x2 down here?
                    if(rand.Next(0, 20) == 5)
                    {
                        //Put a 2x2 here.
                        block[y, x] = BlockContent.B2x2;
                        block[y + 2, x] = BlockContent.Filled;
                        block[y, x + 2] = BlockContent.Filled;
                        block[y + 2, x + 2] = BlockContent.Filled;

                        //Remove the roads between them.
                        block[y + 1, x] = BlockContent.Empty;
                        block[y, x + 1] = BlockContent.Empty;
                        block[y + 1, x + 2] = BlockContent.Empty;
                        block[y + 2, x + 1] = BlockContent.Empty;
                    }
                }
            }
        }
        
        //Fill T buildings ¬ (BDL)

        /*
         *  0 1 2 3 4 5 6 
         *  - - - - - - - 0  
         *  - b - b - b - 1
         *  - - - - - - - 2
         *  - b - b - b - 3
         *  - - - - - - - 4
         *  - b - b - b - 5
         *  - - - - - - - 6
         *  
         */
         
        for(int x = 5; x >= 3; x -= 2)
        {
            for(int y = 1; y <= 3; y += 2)
            {
                //Can I put a ¬ here?
                if(block[y,x] == BlockContent.Building && block[y+2, x] == BlockContent.Building && block[y,x-2] == BlockContent.Building)
                {
                    //Do I want to put a ¬ here?
                    if(rand.Next(0, 10) == 5)
                    {
                        //Put a ¬ here
                        block[y, x] = BlockContent.BDL;
                        block[y + 2, x] = BlockContent.Filled;
                        block[y, x - 2] = BlockContent.Filled;

                        //Remove the roads between them.
                        block[y + 1, x] = BlockContent.Empty;
                        block[y, x - 1] = BlockContent.Empty;
                    }
                }
            }
        }
        
        //Fill T buildings |- (BDR)

        /*
         *  0 1 2 3 4 5 6 
         *  - - - - - - - 0  
         *  - b - b - b - 1
         *  - - - - - - - 2
         *  - b - b - b - 3
         *  - - - - - - - 4
         *  - b - b - b - 5
         *  - - - - - - - 6
         *  
         */
         
        for (int x = 1; x <= 3; x += 2)
        {
            for (int y = 1; y <= 3; y += 2)
            {
                //Can I put a |- here?
                if (block[y, x] == BlockContent.Building && block[y + 2, x] == BlockContent.Building && block[y, x + 2] == BlockContent.Building)
                {
                    //Do I want to put a |- here?
                    if (rand.Next(0, 10) == 5)
                    {
                        //Put a ¬ here
                        block[y, x] = BlockContent.BDR;
                        block[y + 2, x] = BlockContent.Filled;
                        block[y, x + 2] = BlockContent.Filled;

                        //Remove the roads between them.
                        block[y + 1, x] = BlockContent.Empty;
                        block[y, x + 1] = BlockContent.Empty;
                    }
                }
            }
        }
        
        //Fill T buildings |_ (BUR)

        /*
         *  0 1 2 3 4 5 6 
         *  - - - - - - - 0  
         *  - b - b - b - 1
         *  - - - - - - - 2
         *  - b - b - b - 3
         *  - - - - - - - 4
         *  - b - b - b - 5
         *  - - - - - - - 6
         *  
         */
         
        for (int x = 1; x <= 3; x += 2)
        {
            for (int y = 3; y <= 5; y += 2)
            {
                //Can I put a |_ here?
                if (block[y, x] == BlockContent.Building && block[y - 2, x] == BlockContent.Building && block[y, x + 2] == BlockContent.Building)
                {
                    //Do I want to put a |_ here?
                    if (rand.Next(0, 10) == 5)
                    {
                        //Put a ¬ here
                        block[y, x] = BlockContent.BUR;
                        block[y - 2, x] = BlockContent.Filled;
                        block[y, x + 2] = BlockContent.Filled;

                        //Remove the roads between them.
                        block[y - 1, x] = BlockContent.Empty;
                        block[y, x + 1] = BlockContent.Empty;
                    }
                }
            }
        }
        
        //Fill T buildings _| (BUL)

        /*
         *  0 1 2 3 4 5 6 
         *  - - - - - - - 0  
         *  - b - b - b - 1
         *  - - - - - - - 2
         *  - b - b - b - 3
         *  - - - - - - - 4
         *  - b - b - b - 5
         *  - - - - - - - 6
         *  
         */
         
        for (int x = 3; x <= 5; x += 2)
        {
            for (int y = 3; y <= 5; y += 2)
            {
                //Can I put a _| here?
                if (block[y, x] == BlockContent.Building && block[y - 2, x] == BlockContent.Building && block[y, x - 2] == BlockContent.Building)
                {
                    //Do I want to put a _| here?
                    if (rand.Next(0, 10) == 5)
                    {
                        //Put a ¬ here
                        block[y, x] = BlockContent.BUL;
                        block[y - 2, x] = BlockContent.Filled;
                        block[y, x - 2] = BlockContent.Filled;

                        //Remove the roads between them.
                        block[y - 1, x] = BlockContent.Empty;
                        block[y, x - 1] = BlockContent.Empty;
                    }
                }
            }
        }
        
        //Reassign all intersections.
        /*
         * 
         * 0 1 2 3 4 5 6
         * x - x - x - x 0
         * - b / b / b - 1
         * x / x / x / x 2
         * - b / b / b - 3
         * x / x / x / x 4
         * - b / b / b - 5
         * x - x - x - x 6
         */ 
         
        for(int x = 0; x < 7; x += 2)
        {
            
            for(int y = 0; y < 7; y += 2)
            {
                int numConnections = 4;
                bool N = true;
                bool E = true;
                bool S = true;
                bool W = true;

                //Only count if the piece is an intersection.
                if (block[y,x] == BlockContent.Intersection)
                {
                    //Check up, right, down and left. (checking for access violations).
                    if (x - 1 >= 0)
                    {
                        if (block[y, x - 1] == BlockContent.Empty || block[y, x - 1] == BlockContent.Filled)
                        {
                            numConnections--; W = false;
                        }
                    }
                    if (x + 1 <= 6)
                    {
                        if (block[y, x + 1] == BlockContent.Empty || block[y, x + 1] == BlockContent.Filled)
                        {
                            numConnections--; E = false;
                        }
                    }
                    if (y - 1 >= 0)
                    {
                        if (block[y - 1, x] == BlockContent.Empty || block[y - 1, x] == BlockContent.Filled)
                        {
                            numConnections--; N = false;
                        }
                    }
                    if (y + 1 <= 6)
                    {
                        if (block[y + 1, x] == BlockContent.Empty || block[y + 1, x] == BlockContent.Filled)
                        {
                            numConnections--; S = false;
                        }
                    }

                    //If numConnections is 4 then no change needed.

                    //If 3 connections decide what type of T.
                    if(numConnections == 3)
                    {
                        if (!N)
                            block[y, x] = BlockContent.TS;
                        if (!E)
                            block[y, x] = BlockContent.TW;
                        if (!S)
                            block[y, x] = BlockContent.TN;
                        if (!W)
                            block[y, x] = BlockContent.TE;
                    }

                    //If 2 connections decide if straight or Corner.
                    if(numConnections == 2)
                    {
                        //Corner decisions.
                        if (N && E)
                            block[y, x] = BlockContent.CnrSW;
                        if (E && S)
                            block[y, x] = BlockContent.CnrNW;
                        if (S && W)
                            block[y, x] = BlockContent.CnrNE;
                        if (W && N)
                            block[y, x] = BlockContent.CnrSE;

                        //Straight through decisions.
                        if (N && S)
                            block[y, x] = BlockContent.TwoWayE;
                        if (E && W)
                            block[y, x] = BlockContent.TwoWayN;
                    }

                    //if 1 connections decide direction of deadend.
                    if(numConnections == 1)
                    {
                        if (N)
                            block[y, x] = BlockContent.DeadN;
                        if (E)
                            block[y, x] = BlockContent.DeadE;
                        if (S)
                            block[y, x] = BlockContent.DeadS;
                        if (W)
                            block[y, x] = BlockContent.DeadW;
                    }

                    //if no connections then nothing
                    if (numConnections == 0)
                        block[y, x] = BlockContent.Empty;
                }
            }
        }
        
        
        /*
        int rowLength = block.GetLength(0);
        int colLength = block.GetLength(1);

        for (int i = 0; i < rowLength; i++)
        {
            String a = "";
            for (int j = 0; j < colLength; j++)
            {
                a += string.Format("{0} ", block[i, j].ToString());
            }
            Debug.Log(a);
            Debug.Log(Environment.NewLine + Environment.NewLine);
        }
        */
        drawBlock(location, block);

        yield return true; 
    }

    private void drawBlock(Vector3 position, BlockContent[,] data)
    {
        for(int x = 0; x < 7; x++)
        {
            for(int y = 0; y < 7; y++)
            {
                switch (data[y, x])
                {
                    case BlockContent.B2x1E:
                        GameObject.Instantiate(randomDoubleBuilding(), position + (values[y, x] + values[y, x + 2]) / 2, Quaternion.Euler(0, 0, 0));
                        break;
                    case BlockContent.B2x1S:
                        GameObject.Instantiate(randomDoubleBuilding(), position + (values[y, x] + values[y + 2, x]) / 2, Quaternion.Euler(0, 90, 0));
                        break;
                    case BlockContent.B2x2:
                        GameObject.Instantiate(randomQuadBuilding(), position + values[y + 1, x + 1], Quaternion.Euler(0, 0, 0));
                        break;
                    case BlockContent.BDL:
                        GameObject.Instantiate(randomLBuilding(), position + values[y + 1, x], Quaternion.Euler(0, 90, 0));
                        break;
                    case BlockContent.BDR:
                        GameObject.Instantiate(randomLBuilding(), position + values[y, x + 1], Quaternion.Euler(0, 0, 0));
                        break;
                    case BlockContent.BUL:
                        GameObject.Instantiate(randomLBuilding(), position + values[y, x - 1], Quaternion.Euler(0, 180, 0));
                        break;
                    case BlockContent.BUR:
                        GameObject.Instantiate(randomLBuilding(), position + values[y - 1, x], Quaternion.Euler(0, -90, 0));
                        break;
                    case BlockContent.Building:
                        GameObject.Instantiate(randomSingleBuilding(), position + values[y, x], Quaternion.Euler(0, ((rand.Next(0, 361) % 90) * 90), 0));
                        break;
                    case BlockContent.CnrNE:
                        GameObject.Instantiate(GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().Corner, position + values[y, x], Quaternion.Euler(0, 0, 0));
                        break;
                    case BlockContent.CnrNW:
                        GameObject.Instantiate(GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().Corner, position + values[y, x], Quaternion.Euler(0, -90, 0));
                        break;
                    case BlockContent.CnrSE:
                        GameObject.Instantiate(GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().Corner, position + values[y, x], Quaternion.Euler(0, 90, 0));
                        break;
                    case BlockContent.CnrSW:
                        GameObject.Instantiate(GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().Corner, position + values[y, x], Quaternion.Euler(0, 180, 0));
                        break;
                    case BlockContent.DeadE:
                        GameObject.Instantiate(GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().deadEnd, position + values[y, x], Quaternion.Euler(0, 0, 0));
                        break;
                    case BlockContent.DeadN:
                        GameObject.Instantiate(GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().deadEnd, position + values[y, x], Quaternion.Euler(0, -90, 0));
                        break;
                    case BlockContent.DeadS:
                        GameObject.Instantiate(GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().deadEnd, position + values[y, x], Quaternion.Euler(0, 90, 0));
                        break;
                    case BlockContent.DeadW:
                        GameObject.Instantiate(GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().deadEnd, position + values[y, x], Quaternion.Euler(0, 180, 0));
                        break;
                    case BlockContent.Intersection:
                        GameObject.Instantiate(GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().intersection, position + values[y, x], Quaternion.Euler(0, 0, 0));
                        break;
                    case BlockContent.Plaza:
                        GameObject.Instantiate(GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().plaza, position + values[y, x], Quaternion.Euler(0, 0, 0));
                        break;
                    case BlockContent.RoadRIGHT:
                        GameObject.Instantiate(GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().road, position + values[y, x], Quaternion.Euler(0, 90, 0));
                        break;
                    case BlockContent.RoadUP:
                        GameObject.Instantiate(GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().road, position + values[y, x], Quaternion.Euler(0, 0, 0));
                        break;
                    case BlockContent.TE:
                        GameObject.Instantiate(GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().TJunction, position + values[y, x], Quaternion.Euler(0, 0, 0));
                        break;
                    case BlockContent.TN:
                        GameObject.Instantiate(GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().TJunction, position + values[y, x], Quaternion.Euler(0, -90, 0));
                        break;
                    case BlockContent.TS:
                        GameObject.Instantiate(GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().TJunction, position + values[y, x], Quaternion.Euler(0, 90, 0));
                        break;
                    case BlockContent.TW:
                        GameObject.Instantiate(GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().TJunction, position + values[y, x], Quaternion.Euler(0, 180, 0));
                        break;
                    case BlockContent.TwoWayE:
                        GameObject.Instantiate(GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().TwoWay, position + values[y, x], Quaternion.Euler(0, 0, 0));
                        break;
                    case BlockContent.TwoWayN:
                        GameObject.Instantiate(GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().TwoWay, position + values[y, x], Quaternion.Euler(0, 180, 0));
                        break;
                    case BlockContent.Ship:
                        GameObject.Instantiate(GameStateController.Instance.GetComponent<BuildingPrefabWrapper>().home, position + values[y, x], Quaternion.Euler(0, 0, 0));
                        break;
                }

                        
            }
        }
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
