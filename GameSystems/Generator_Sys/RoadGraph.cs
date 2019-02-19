using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGraph<T> : Graph<T> where T : RoadNode
{

    // The adjacency list: maps a node to a set containing the neighbours of that node
    private Dictionary<T, HashSet<T>> adjacencyList = new Dictionary<T, HashSet<T>>();

    // Fields used to keep the number of nodes and edges in the graph
    private int noOfNodes = 0, noOfEdges = 0;

    /**
     * Check if the graph contains a given node.
     *
     * @param node the node to be checked.
     * @return (<tt>node</tt> is a node in the graph).
     */
    public bool contains(T node)
    {
        return getNodes().Contains(node);
    }

    /**
     * Check if the graph contains a given edge between two nodes.
     *
     * @param start the start node of the edge to be checked.
     * @param end the end node of the edge to be checked.
     * @return (there is an edge from <tt>start</tt> to <tt>end</tt> in the graph).
     */
    public bool contains(T start, T end)
    {
        // check that both nodes are in the graph, and then check that "end" is in
        // "start"'s entry in the adjacency list
        return contains(start) && contains(end) && adjacencyList[start].Contains(end);

    }

    /**
     * Add a node to the graph.
     *
     * @param node the node to be added.
     * @throws GraphError if the node is already in the graph.
     */
    public void add(T node)
    {
        if (contains(node))
        {
            throw new GraphError("Cannot add " + node + " to the graph.  This node is already in the graph.");
        }
        else
        {
            // Add a new entry to the adjacency list.  This is a new node, so it will not yet have any
            // neighbours, so its entry in the adjacency list will be a new, empty, set
            adjacencyList.Add(node,new HashSet<T>());
            // increase number of nodes
            noOfNodes++;
        }
    }

    /**
     * Remove a node, and all edges leading to and from it, from the graph.
     *
     * @param node the node to be reomoved - all edges leaving the node, and all edges entering the node
     *             will also be deleted.
     * @throws GraphError if the node does not exist.
     */
    public void remove(T node)
    {
        if (!contains(node))
        {
            throw new GraphError("Cannot remove " + node + " from the graph.  No such node.");
        }
        else
        {
            // remove the node and all edges leaving it by removing its entry in the adjacency list
            // before doing so reduce the number of edges about to be removed
            noOfEdges -= getNeighbours(node).Count;
            adjacencyList.Remove(node);
            // reduce number of nodes
            noOfNodes--;
            // remove any links to the node by removing the node, if present, from all of the remaining
            // entries in the adjacencyList
            foreach (T start in adjacencyList.Keys)
            {
                if (contains(start, node))
                {
                    // reduce number of edges
                    noOfEdges--;
                    // remove edge
                    remove(start, node);
                }
            }
        }
    }

    /**
     * Add an edge to the graph.
     *
     * @param start the start node of the edge to be added.
     * @param end the end node of the edge to be added.
     * @throws GraphError if the edge already exists, or if either <tt>start</tt> or <tt>end</tt> is not a node in the graph
     */
    public void add(T start, T end)
    {
        if (contains(start,end))
        {
            throw new GraphError("Cannot add " + start + "==>" + end + " to the graph.  This edge is already in the graph.");
        }
        else if (!contains(start) || !contains(end))
        {
            throw new GraphError("Cannot add " + start + "==>" + end + " to the graph.  One or both of the nodes on this edge is not in the graph.");
        }
        else
        {
            // add the edge by adding "end" to "start"'s entry in the adjacency list
            adjacencyList[start].Add(end);
            // increase number of edges
            noOfEdges++;
        }
    }

    /**
     * Remove an edge from the graph.
     *
     * @param start the start node of the edge to be removed.
     * @param end the end node of the edge to be removed.
     * @throws GraphError if there is no such edge in this graph
     */
    public void remove(T start, T end)
    {
        if (!contains(start,end))
        {
            throw new GraphError("Cannot remove " + start + "==>" + end + " from the graph.  There is no such edge in the graph.");
        }
        else
        {
            // delete "end" from "start"'s entry in the adjacency list
            adjacencyList[start].Remove(end);
            // decrease the number of edges
            noOfEdges--;
        }
    }

    /**
     * Get the neighbours of a given node.
     *
     * @param node the node for which the neighbours should be found.
     * @return a set of the immediate successors of the node.
     * @throws GraphError if the node is not a node in the graph
     */
    public HashSet<T> getNeighbours(T node)
    {
        // The neighbours can be accessed through this node's entry in the adjacency list.
        // Note: Create a copy of the entry to avoid users being able to change the adjacency list.
        HashSet<T> copy = new HashSet<T>();
        foreach (T member in adjacencyList[node]) {
            copy.Add(member);
        }
        return copy;
    }

    /**
     * Get the number of nodes in the graph.
     *
     * @return the number of nodes currently in this graph
     */
    public int getNoOfNodes()
    {
        return noOfNodes;
    }

    /**
     * Get all the nodes in the graph.
     *
     * @return a set containing all the nodes in this graph
     */
    public HashSet<T> getNodes()
    {
        // Note: The nodes can be accessed through the adjacency list's key set.
        // Note: Create a copy of the key set to avoid users being able to change the adjacency list
        HashSet<T> copy = new HashSet<T>();
        foreach (T member in adjacencyList.Keys)
        {
            copy.Add(member);
        }
        return copy;
    }

    public T GetNode(Vector2 location)
    {
        foreach(T member in adjacencyList.Keys)
        {
            if(member.getLocation().x == location.x && member.getLocation().y == location.y)
            {
                return member;
            }
        }

        return null;
    }

    /**
     * Get the number of edges in the graph.
     *
     * @return the number of edges currently in this graph
     */
    public int getNoOfEdges()
    {
        return noOfEdges;
    }
}


