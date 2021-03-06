using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class SlimeMovement : Movement
{


    
    private float rest_timer = 0;
    private float move_timer = 0;
    private float timer = 0.0f;
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
        //GetComponent<SpriteRenderer>().color = Color.red;

        if (base.speed == initial_speed)
        {
            GetComponent<SpriteRenderer>().color = color; 
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (timer >= rest_timer + move_timer)
        {
            timer = 0.0f;
            rest_timer = Random.Range(0.1f, 2.0f);
            move_timer = Random.Range(0.1f, 1.0f);
        }
        timer += Time.deltaTime;
        base.FixedUpdate();
    }

    public override Vector2 GetInput()
    {
        if(timer < rest_timer)
        {
            return Vector2.zero; 
        }
        return Vector2.right;
    }
}
