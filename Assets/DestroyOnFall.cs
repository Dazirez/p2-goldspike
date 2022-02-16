using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnFall : MonoBehaviour
{
    // Update is called once per frame
    private bool dead = false;
    public int score_value = 10;
    void Update()
    {
        if(!dead && transform.position.z > 0.001) {
            GetComponent<Movement>().enabled = false;
            GetComponent<SpriteRenderer>().sortingOrder = -1; 
            dead = true;
            EventBus.Publish<ScoreEvent>(new ScoreEvent(score_value));
            StartCoroutine(Death()); 
        }
        if(transform.position.z > 10) {
            Destroy(gameObject);
        }
    }
    IEnumerator Death()
    {
        Debug.Log("died"); 
        yield return null;
    }
}
