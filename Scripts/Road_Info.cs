using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Info : MonoBehaviour {

    private bool usedByGenerator = false;

    public void setUsed()
    {
        usedByGenerator = true;
    }

    public bool getUsed()
    {
        return this.usedByGenerator;
    }
}
