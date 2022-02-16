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
    public void OnTriggerEnter(Collider other)
    {

        if (disabled) return; 
        Rigidbody other_rb = other.GetComponent<Rigidbody>();

        
        /* Perform Knockback */
        if (other_rb != null)
        {
            StartCoroutine(Stun(other)); 

            EventBus.Publish<CollisionEvent>(new CollisionEvent(knockback_power));

            Vector3 knockback_direction = (other.transform.position - transform.position).normalized;
            other_rb.velocity = Vector2.zero;
            knockback_direction.x = -Math.Abs(knockback_direction.x);
          
            other_rb.AddForce(knockback_direction.normalized * knockback_power, ForceMode.Impulse);
            /////* Determine Knockback direction -> horizontal vs vertical */
            //if (Math.Abs(knockback_direction.x) > Math.Abs(knockback_direction.y))
            //{
               
            //    other_rb.AddForce(new Vector2(-knockback_power, 0f), ForceMode.Impulse);
            //    // other_rb.velocity = new Vector2(-knockback_power, 0f);

               
            //}
            //else
            //{
            //    if (knockback_direction.y > 0)
            //    {
            //        other_rb.AddForce(new Vector2(0f, knockback_power), ForceMode.Impulse);
            //        // other_rb.velocity = new Vector2(0f, knockback_power);

            //    }
            //    else
            //    {
            //        other_rb.AddForce(new Vector2(0f, -knockback_power), ForceMode.Impulse);
            //        // other_rb.velocity = new Vector2(0f, -knockback_power);

            //    }
            //}

        }


        /* Destroy self */
        if (destroy_self_on_touch)
            Destroy(gameObject);
    }

  
    private IEnumerator Stun(Collider other)
    {
        SpriteRenderer sprite = other.GetComponent<SpriteRenderer>();
        Movement mv = other.GetComponent<Movement>();
        float timer = 0.05f;
        mv.enabled = false; 
        while (timer > 0.0f)
        {
            timer -= Time.deltaTime; 
            sprite.enabled = false;
            yield return new WaitForSeconds(0.05f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.05f);
        }
        mv.enabled = true; 

    }
}
