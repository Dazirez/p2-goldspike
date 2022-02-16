using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public int damage_amount = 10; 
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("finishline"))
        {
            EventBus.Publish<DamageEvent>(new DamageEvent(damage_amount));
        }
    }
}
