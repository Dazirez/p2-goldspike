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
    public float power = 0f; 
    public CollisionEvent(float _power) {
        power = _power; 
    }
}


public class DashEvent
{
    public DashEvent() { }
}

public class DamageEvent
{
    public int damage_amount = 0;
    public DamageEvent(int _damage_amount)
    {
        damage_amount = _damage_amount;
    }
}