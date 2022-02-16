using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;


public class Movement : MonoBehaviour
{
    public float speed = 25f;

    Vector2 current_direction; 
    protected Rigidbody rb;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        rb.velocity = current_direction * speed;
    }

    public virtual Vector2 GetInput() {
        return Vector2.zero; 
    }
    public Vector2 GetDirection()
    {
        return current_direction; 
    }
}
