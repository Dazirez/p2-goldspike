using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class DragonMovement : Movement
{



    protected override void FixedUpdate()
    {

        base.FixedUpdate();
    }

    public override Vector2 GetInput()
    {

        return Vector2.right;
    }
}
