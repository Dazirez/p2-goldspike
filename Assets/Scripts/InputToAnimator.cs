using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToAnimator : MonoBehaviour
{
    Animator animator;
    Movement movement;
    Subscription<DashEvent> dash_event_subscription;
    Subscription<SwordSwingEvent> sword_swing_event_subscription;
    Subscription<GroundPoundEvent> ground_pound_event_subscription;
    Subscription<LevelUpEvent> level_up_event_subscription;

    public float level_up_timer = 2.0f;
    float timer; 
    private bool facingRight = false; 
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<Movement>();
        dash_event_subscription = EventBus.Subscribe<DashEvent>(_OnDash);
        sword_swing_event_subscription = EventBus.Subscribe<SwordSwingEvent>(_OnSwing);
        ground_pound_event_subscription = EventBus.Subscribe<GroundPoundEvent>(_OnGroundPound);
        level_up_event_subscription = EventBus.Subscribe<LevelUpEvent>(_OnLevelUp); 
    }

    void _OnDash(DashEvent e)
    {
        animator.SetTrigger("dash");

    }
    void _OnSwing(SwordSwingEvent e)
    {
        animator.SetTrigger("sword");
    }

    void _OnGroundPound(GroundPoundEvent e)
    {
        animator.SetTrigger("groundpound");
    }
    void _OnLevelUp(LevelUpEvent e)
    {
        animator.SetTrigger("levelup");
        StartCoroutine(LevelUp());
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
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
    IEnumerator LevelUp()
    {
        timer = 0f;
        while(timer < level_up_timer)
        {
            GetComponent<Rigidbody>().velocity = Vector2.zero;
            movement.enabled = false;
            yield return null; 
        }
        yield return new WaitForSeconds(0.5f);
        movement.enabled = true;
    }
    private void OnDestroy()
    {
        EventBus.Unsubscribe(dash_event_subscription);
        EventBus.Unsubscribe(sword_swing_event_subscription);
        EventBus.Unsubscribe(ground_pound_event_subscription);
        EventBus.Unsubscribe(level_up_event_subscription); 
    }
}
