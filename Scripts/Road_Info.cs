using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Info : MonoBehaviour {

    public bool usedByGenerator = false;
    public Vector2 location = new Vector2(0,0);

    public void setUsed(bool used)
    {
        usedByGenerator = used;
    }

    public void hasBeenUsed()
    {
        usedByGenerator = true;
    }

    public bool getUsed()
    {
        return this.usedByGenerator;
    }

    public void setLocation(int x, int y)
    {
        this.location.x = x;
        this.location.y = y;
    }


}
