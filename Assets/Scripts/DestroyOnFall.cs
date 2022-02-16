using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnFall : MonoBehaviour
{
    // Update is called once per frame
    public bool dead = false;
    public int score_value = 10;
    void Update()
    {
        if(dead)
        {
            GetComponent<Movement>().enabled = false;

        }
        if (!dead && transform.position.z > 0.001) {
            GetComponent<SpriteRenderer>().sortingOrder = -1; 
            dead = true;
            EventBus.Publish<ScoreEvent>(new ScoreEvent(score_value));
        }
        if(transform.position.z > 10) {
            Destroy(gameObject);
        }
    }
 
}
