using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasGravity : MonoBehaviour
{
    public float gravity_strength;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, 0, gravity_strength);
    }

}
