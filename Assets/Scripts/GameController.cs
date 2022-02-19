using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{

    public static GameController instance;

    Subscription<DamageEvent> damage_event_subscription;
    Subscription<ScoreEvent> death_event_subscription;

    public HealthBar healthBar;
    public HealthBar XPBar;

    public int maxHealth = 100;
    public int currentHealth = 100;

    public int currentXP = 0;
    public int maxXP = 100; 

    public int enemies_left;

    public int current_level = 0;
    public int player_level = 1;

    public string[] levels; 
    void Awake()
    {
        if (instance == null)
        {
            healthBar.SetMaxHealth(maxHealth);
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
        if (currentXP >= 100)
        {
            currentXP %= 100;
            XPBar.SetHealth(currentXP);

            player_level++;
            EventBus.Publish<LevelUpEvent>(new LevelUpEvent(player_level));
        }

    }

    void _OnScoreUpdated(ScoreEvent e)
    {
        currentXP += e.new_score;
        XPBar.SetHealth(currentXP);
        enemies_left--;
    }
    void LoadNext()
    {
        current_level = (current_level + 1) % levels.Length;
        SceneManager.LoadScene(levels[current_level], LoadSceneMode.Single);
    }

    void _OnDamageUpdate(DamageEvent e)
    {
        currentHealth -= e.damage_amount;
        healthBar.SetHealth(currentHealth);
        enemies_left--;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
}
