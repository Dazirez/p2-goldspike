using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
[DisallowMultipleComponent]
public class KnockbackOnEnter : MonoBehaviour
{
    public float knockback_power = 20f;
    public bool destroy_self_on_touch = false;
    public bool disabled = true; 
    public void OnTriggerStay(Collider other)
    {

        if (disabled) return; 
        Rigidbody other_rb = other.GetComponent<Rigidbody>();

        
        /* Perform Knockback */
        if (other_rb != null)
        {
            other.GetComponent<GetsStunned>().Stun(); 

            EventBus.Publish<CollisionEvent>(new CollisionEvent(knockback_power));

            Vector3 knockback_direction = (other.transform.position - transform.position).normalized;
            other_rb.velocity = Vector2.zero;
            knockback_direction.x = -Math.Abs(knockback_direction.x);
          
            other_rb.AddForce(knockback_direction.normalized * knockback_power, ForceMode.Impulse);

        }
        /* Destroy self */
        if (destroy_self_on_touch)
            Destroy(gameObject);
    }
}
