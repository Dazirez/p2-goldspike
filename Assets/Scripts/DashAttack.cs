using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttack : MonoBehaviour
{
    private Rigidbody rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dashTime = startDashTime; 
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == 0)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = 1; 
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = 2; 
            }
            else if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = 3; 
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = 4; 
            }
        }
        else
        {
            if(dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero; 
            }
            else {
                dashTime -= Time.deltaTime;
                if(direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed; 
                }
                else if(direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed; 
                }
                else if(direction == 3)
                {
                    rb.velocity = Vector2.up * dashSpeed; 
                }
                else if(direction == 4)
                {
                    rb.velocity = Vector2.down * dashSpeed; 
                }
            }
        }
    }

    //public void Attack()
    //{
    //    rb.velocity = Vector3.zero; 
    //    timer = 0f;
    //    Vector2 direction = mv.Get_Direction();
    //    Debug.Log("curr dash: " + direction);
    //    rb.AddForce(direction * force, ForceMode.Impulse); 
        
    //}
}
