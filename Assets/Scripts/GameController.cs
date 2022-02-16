using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{

    public static GameController instance;

    Subscription<DamageEvent> damage_event_subscription; 

    public int health = 100;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        damage_event_subscription = EventBus.Subscribe<DamageEvent>(_OnDamageUpdate);

    }

    void _OnDamageUpdate(DamageEvent e)
    {
        health -= e.damage_amount;
        if(health < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
}
