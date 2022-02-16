using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetsStunned : MonoBehaviour
{
    public float timer = 2f;
    private bool stunned = false;

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;

    }
    public void Stun(float knockback_power)
    {
        if (!stunned)
        {
            stunned = true; 
            StartCoroutine(Stunned(knockback_power));

        }
    }
    private IEnumerator Stunned(float knockback_power)
    {
        EventBus.Publish<CollisionEvent>(new CollisionEvent(knockback_power));

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        Movement mv = GetComponent<Movement>();
        timer = 2f;
        mv.enabled = false;
        while(timer > 0)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(0.05f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.05f);
        }
        yield return null;
        mv.enabled = true;
        stunned = false; 
    }
}
