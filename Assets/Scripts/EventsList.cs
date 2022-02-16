using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ScoreEvent
{
    public int new_score = 0;
    public ScoreEvent(int _new_score) { new_score = _new_score; }

    public override string ToString()
    {
        return "new_score : " + new_score;
    }
}

public class CollisionEvent
{
    public CollisionEvent() { }
}


public class DashEvent
{
    public DashEvent() { }
}
