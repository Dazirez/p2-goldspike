using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToAnimator : MonoBehaviour
{
    Animator animator;
    Movement movement;
    Subscription<DashEvent> dash_event_subscription;
    private bool facingRight = false; 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<Movement>();
        dash_event_subscription = EventBus.Subscribe<DashEvent>(_OnDash);

    }

    void _OnDash(DashEvent e)
    {
        animator.SetTrigger("dash");

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
        else if(x > 0) 
        {
            if(!facingRight)
            {
                Flip();
            }
            animator.SetBool("idle", false);
        }
        else if(x < 0)
        {
            if(facingRight)
            {
                Flip();

            }

            animator.SetBool("idle", false);
        }
        else
        {
            animator.SetBool("idle", false);

        }
    }
    void Flip()
    {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
