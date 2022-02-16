using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{

    public static GameController instance;

    Subscription<DamageEvent> damage_event_subscription;
    Subscription<ScoreEvent> death_event_subscription;

    public int health = 100;
    public int score = 0; 
    public int current_level; 
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
        death_event_subscription = EventBus.Subscribe<ScoreEvent>(_OnScoreUpdated);

    }

    void _OnScoreUpdated(ScoreEvent e)
    {
        score += e.new_score;
        if(score >= 10)
        {
            LoadNext(); 
        }
    }
    void LoadNext()
    {
        if(current_level == 1)
        {
            current_level = 2; 
            SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
        }
        else if(current_level == 2)
        {
            current_level = 3;
            SceneManager.LoadScene("Level 3", LoadSceneMode.Single);

        }
        else if (current_level == 3)
        {
            current_level = 1;
            SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
        }
    }

    void _OnDamageUpdate(DamageEvent e)
    {
        health -= e.damage_amount;
        Debug.Log("heatlh: " + health); 
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
}
