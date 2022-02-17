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
    public int current_level = 0;
    public int[] num_enemies;
    public string[] levels; 
    void Awake()
    {
        enemies_left = num_enemies[current_level];
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            damage_event_subscription = EventBus.Subscribe<DamageEvent>(_OnDamageUpdate);
            death_event_subscription = EventBus.Subscribe<ScoreEvent>(_OnScoreUpdated);
            instance = this;
        }
        else if (instance != this)
        {
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
        current_level = (current_level + 1) % levels.Length;
        SceneManager.LoadScene(levels[current_level], LoadSceneMode.Single);
        enemies_left = num_enemies[current_level];
        Debug.Log("Current level: " + current_level); 
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
            enemies_left = num_enemies[current_level];
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
}
