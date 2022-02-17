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
    public int[] enemies;
    public string[] levels; 
    void Awake()
    {
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

    private void Update()
    {
        enemies_left = GameObject.FindGameObjectsWithTag("enemy").Length;
        if (enemies_left <= 0)
        {
            LoadNext();
        }

    }

    void _OnScoreUpdated(ScoreEvent e)
    {
        score += e.new_score;
        enemies_left--;
    }
    void LoadNext()
    {
        current_level = (current_level + 1) % levels.Length;
        SceneManager.LoadScene(levels[current_level], LoadSceneMode.Single);
    }

    void _OnDamageUpdate(DamageEvent e)
    {
        health -= e.damage_amount;
        enemies_left--;
        
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
}
