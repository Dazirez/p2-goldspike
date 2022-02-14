using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    protected virtual void Update()
    {
        Vector2 curr_input = GetInput();
        rb.velocity = curr_input * speed; 
    }

    protected virtual Vector2 GetInput() {
        return Vector2.zero; 
    }
}
