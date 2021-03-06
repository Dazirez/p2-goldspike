using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class WitchMovement : Movement
{


    Animator animator; 
    private float rest_timer = 0;
    private float move_timer = 0;
    private float timer = 0.0f;
    bool attacking = false; 
    protected override void Start()
    {

        rest_timer = Random.Range(0.5f, 1.0f);
        move_timer = Random.Range(1.0f, 2.0f);
        timer = rest_timer; 
        animator = GetComponent<Animator>(); 
        base.Start();
    }
    protected override void FixedUpdate()
    {
        if (timer >= rest_timer + move_timer)
        {
            timer = 0.0f;
            rest_timer = Random.Range(2.0f, 5.0f);
            move_timer = Random.Range(3.0f, 5.0f);
        }
        timer += Time.deltaTime;
        base.FixedUpdate();
    }

    public override Vector2 GetInput()
    {
        if (timer < rest_timer)
        {
            animator.SetBool("attacking", true);
            if(!attacking)
            {
                ToggleWitchAttack(); 
            }
            return Vector2.zero;
        }
        else
        {
            animator.SetBool("attacking", false);
            if(attacking)
            {
                ToggleWitchAttack(); 
            }
            return Vector2.right;
        }
       
    }

    public void ToggleWitchAttack()
    {
        attacking = !attacking;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy"); 
        if(attacking)
        {
            EventBus.Publish<WitchEvent>(new WitchEvent());

            GetComponent<Rigidbody>().mass = 10; 
            foreach (GameObject enemy in enemies)
            {
                if(!enemy.CompareTag("witch"))
                {
                    enemy.GetComponent<Movement>().speed += 1;

                }
            }
        }
        else
        {
            GetComponent<Rigidbody>().mass = 3;

            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<Movement>().speed -= 1;

            }
        }
    }
    protected override void OnDestroy()
    {
        if(attacking)
        {
            ToggleWitchAttack(); 
        }
        base.OnDestroy();
    }
}
