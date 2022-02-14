using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;


public class Movement : MonoBehaviour
{
    public float speed = 25f;

    protected Vector2 curr_direction; 
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
        if(Abs(curr.x) > 0 || Abs(curr.y) > 0)
        {
            curr_direction = curr; 
        }
        Debug.Log("curr:" + curr_direction);
        rb.velocity = curr * speed;
    }

    protected virtual Vector2 GetInput() {
        return Vector2.zero; 
    }

    public Vector2 Get_Direction() {
        return curr_direction; 
    }
}
