using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;


public class Movement : MonoBehaviour
{
    public float speed = 25f;

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
        rb.velocity = curr * speed;
    }

    protected virtual Vector2 GetInput() {
        return Vector2.zero; 
    }

}
