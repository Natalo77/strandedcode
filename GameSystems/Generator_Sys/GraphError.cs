using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GraphError : Exception
{
    public GraphError() : base("Unspecified exception")
    {
    }

    public GraphError(string message) : base(message)
    {
    }

    public GraphError(string message, Exception inner) : base(message, inner)
    {
    }
}
