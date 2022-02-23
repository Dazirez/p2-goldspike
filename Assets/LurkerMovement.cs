using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class LurkerMovement : Movement
{

    Animator animator;
    private float rest_timer; 
    private float timer;
    private bool is_moving;
    private bool played = false; 
    protected override void Start()
    {
        animator = GetComponent<Animator>(); 
        rest_timer = Random.Range(1.0f, 20.0f);
        is_moving = false; 
        base.Start();

    }
    protected override void FixedUpdate()
    {
        if(is_moving)
        {
            if(!played)
            {
                EventBus.Publish<LurkerEvent>(new LurkerEvent());
                played = true; 
            }

            if (base.speed > 3.0f)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
                base.rb.mass = 0.5f; 
            }
            animator.speed *= 1.005f; 
            base.speed *= 1.01f;
        }
        timer += Time.deltaTime;
        base.FixedUpdate();
    }

    public override Vector2 GetInput()
    {
        if (timer < rest_timer)
        {
            return Vector2.zero;
        }
        animator.SetBool("is_moving", true);
        is_moving = true; 
        return Vector2.right;
    }
}
