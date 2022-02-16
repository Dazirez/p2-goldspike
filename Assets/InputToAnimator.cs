using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToAnimator : MonoBehaviour
{
    Animator animator;
    Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = movement.GetInput().x;
        float y = movement.GetInput().y;

        if (!movement.enabled || (x == 0 && y == 0))
        {
            animator.SetBool("idle", true);

            //if(!is_player) Debug.Log("disabling movement animation"); 
            //animator.speed = 0.0f;
        }
        else
        {
            animator.SetBool("idle", false);
        }
    }
}
