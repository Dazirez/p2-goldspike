using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour
{
    public float timer = 2f;
    private bool stunned = false;

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;

    }
    public void GetStunned()
    {
        if (!stunned)
        {
            StartCoroutine(Stunned());

        }
    }
    private IEnumerator Stunned()
    {
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
