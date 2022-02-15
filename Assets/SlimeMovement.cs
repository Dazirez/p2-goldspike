using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class SlimeMovement : Movement
{


    public float rest_timer = 2.0f;
    private float timer = 0.0f; 


    protected override void FixedUpdate()
    {
        rest_timer -= Time.deltaTime;
        base.FixedUpdate();
    }

    protected override Vector2 GetInput()
    {
        return Vector2.right;
    }
}
