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
    public int enemies_left;
    public int score = 0; 
    public int current_level;
    public int[] num_enemies;

    void Awake()
    {
       
        if (instance == null)
        {
            enemies_left = num_enemies[current_level - 1];

            damage_event_subscription = EventBus.Subscribe<DamageEvent>(_OnDamageUpdate);
            death_event_subscription = EventBus.Subscribe<ScoreEvent>(_OnScoreUpdated);
            instance = this;
        }
        else if (instance != this)
        {
            EventBus.Unsubscribe(damage_event_subscription);
            EventBus.Unsubscribe(death_event_subscription);
            Destroy(gameObject);
        }
    }
    //// Start is called before the first frame update
    //void Start()
    //{
    //    damage_event_subscription = EventBus.Subscribe<DamageEvent>(_OnDamageUpdate);
    //    death_event_subscription = EventBus.Subscribe<ScoreEvent>(_OnScoreUpdated);
    //}

    void _OnScoreUpdated(ScoreEvent e)
    {
        score += e.new_score;
        enemies_left--;
        if (enemies_left <= 0)
        {
            enemies_left = num_enemies[current_level % num_enemies.Length];
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
        enemies_left--;
        if (enemies_left <= 0)
        {
            enemies_left = num_enemies[current_level % num_enemies.Length];
            LoadNext();
        }
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
}
