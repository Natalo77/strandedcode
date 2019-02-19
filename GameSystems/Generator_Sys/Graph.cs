using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Graph<T>
{

    /**
     * Check if the graph contains a given node.
     *
     * @param node the node to be checked.
     * @return (<tt>node</tt> is a node in the graph).
     */
    bool contains(T node);

    /**
     * Check if the graph contains a given edge between two nodes.
     *
     * @param start the start node of the edge to be checked.
     * @param end the end node of the edge to be checked.
     * @return (there is an edge from <tt>start</tt> to <tt>end</tt> in the graph).
     */
    bool contains(T start, T end);

    /**
     * Add a node to the graph.
     *
     * @param node the node to be added.
     * @throws GraphError if the node is already in the graph.
     */
    void add(T node);

    /**
     * Remove a node, and all edges leading to and from it, from the graph.
     *
     * @param node the node to be reomoved - all edges leaving the node, and all edges entering the node
     *             will also be deleted.
     * @throws GraphError if the node does not exist.
     */
    void remove(T node);

    /**
     * Add an edge to the graph.
     *
     * @param start the start node of the edge to be added.
     * @param end the end node of the edge to be added.
     * @throws GraphError if the edge already exists, or if either <tt>start</tt> or <tt>end</tt> is not a node in the graph
     */
    void add(T start, T end);

    /**
     * Remove an edge from the graph.
     *
     * @param start the start node of the edge to be removed.
     * @param end the end node of the edge to be removed.
     * @throws GraphError if there is no such edge in this graph
     */
    void remove(T start, T end);

    /**
     * Get the neighbours of a given node.
     *
     * @param node the node for which the neighbours should be found.
     * @return a set of the immediate successors of the node.
     * @throws GraphError if the node is not a node in the graph
     */
    HashSet<T> getNeighbours(T node);

    /**
     * Get the number of nodes in the graph.
     *
     * @return the number of nodes currently in this graph
     */
    int getNoOfNodes();

    /**
     * Get all the nodes in the graph.
     *
     * @return a set containing all the nodes in this graph
     */
    HashSet<T> getNodes();

    /**
     * Get the number of edges in the graph.
     *
     * @return the number of edges currently in this graph
     */
    int getNoOfEdges();

}