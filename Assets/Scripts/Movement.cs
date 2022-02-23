using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;


public class Movement : MonoBehaviour
{
    Subscription<LevelUpEvent> level_up_event_subscription;

    public float speed = 25f;

    Vector2 current_direction; 
    protected Rigidbody rb;
    bool isenabled = true; 

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        level_up_event_subscription = EventBus.Subscribe<LevelUpEvent>(_OnLevelUp);

    }
    void _OnLevelUp(LevelUpEvent e)
    {
        StartCoroutine(LevelUp());
    }
    IEnumerator LevelUp()
    {
        isenabled = false;
        yield return new WaitForSeconds(0.5f);
        isenabled = true; 
    }
    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        Vector2 curr = GetInput();
        if (curr == Vector2.zero) {
            rb.velocity = Vector2.zero;
            return;
        } 
        else
        {
            current_direction = curr; 
        }
        if (!isenabled) current_direction = Vector2.zero;

        rb.velocity = current_direction * speed;
    }

    public virtual Vector2 GetInput() {
        return Vector2.zero; 
    }
    public Vector2 GetDirection()
    {
        return current_direction; 
    }

    protected virtual void OnDestroy()
    {
        EventBus.Unsubscribe(level_up_event_subscription);

    }
}
