using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasGravity : MonoBehaviour
{
    public float gravity_strength;
    Rigidbody rb; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(0, 0, gravity_strength)); 
    }
}
