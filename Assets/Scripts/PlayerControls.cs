using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    DashAttack attack1;
    // Update is called once per frame
    private void Start()
    {
        attack1 = GetComponent<DashAttack>(); 
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            attack1.Attack(); 
        }
    }
}
