using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class DragonMovement : Movement
{

    private float initial_speed;
    Color color;
    protected override void Start()
    {
        color = GetComponent<SpriteRenderer>().color;
        initial_speed = base.speed;
        base.Start();
    }

    protected override void FixedUpdate()
    {
        if (base.speed == initial_speed)
        {
            GetComponent<SpriteRenderer>().color = color;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        base.FixedUpdate();
    }

    public override Vector2 GetInput()
    {

        return Vector2.right;
    }
}
