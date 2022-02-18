using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnFall : MonoBehaviour
{
    // Update is called once per frame
    public bool dead = false;
    public int score_value = 10;
    public float lower_bound;
    public float upper_bound;
    public float left_bound; 
    void Update()
    {
        if(dead)
        {
            GetComponent<Movement>().enabled = false;
            Animator an = GetComponent<Animator>();
            if(an != null)
            {
                an.enabled = false; 
            }
        }
        if (!dead && (transform.position.y > upper_bound || transform.position.y < lower_bound || transform.position.x < left_bound || transform.position.z > 0.5)) {
            GetComponent<Rigidbody>().velocity = Vector2.zero;
            GetComponent<SpriteRenderer>().sortingOrder = -1; 
            dead = true;
            EventBus.Publish<ScoreEvent>(new ScoreEvent(score_value));
        }
        if(transform.position.z > 10) {
            Destroy(gameObject);
        }
    }
 
}
