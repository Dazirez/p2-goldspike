using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttack : MonoBehaviour
{
    Movement mv;
    Rigidbody rb;

    public float force = 1f; 
    public float cooldown = 5f;
    private float timer = 5f; 
    // Start is called before the first frame update
    void Start()
    {
        mv = GetComponent<Movement>();
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; 
    }

    public void Attack()
    {
        rb.velocity = Vector3.zero; 
        timer = 0f;
        Vector2 direction = mv.Get_Direction();
        Debug.Log("curr dash: " + direction);
        rb.AddForce(direction * force, ForceMode.Impulse); 
        
    }
}
