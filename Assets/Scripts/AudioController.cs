using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    Subscription<CollisionEvent> collision_event_subscription;
    Subscription<DamageEvent> damage_event_subscription;
    Subscription<LevelUpEvent> level_up_event_subscription;
    Subscription<LurkerEvent> lurker_event_subscription;
    Subscription<WitchEvent> witch_event_subscription;

    public static AudioController instance;
    public AudioClip[] clips;
    // Start is called before the first frame update
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
    private void Start()
    {
        collision_event_subscription = EventBus.Subscribe<CollisionEvent>(_OnCollisionUpdated);
        damage_event_subscription = EventBus.Subscribe<DamageEvent>(_OnDamageUpdate);
        level_up_event_subscription = EventBus.Subscribe<LevelUpEvent>(_OnLevelUp);
        lurker_event_subscription = EventBus.Subscribe<LurkerEvent>(_OnLurkerEvent);
        witch_event_subscription = EventBus.Subscribe<WitchEvent>(_OnWitchEvent);
    }
    void _OnCollisionUpdated(CollisionEvent e)
    {
        play_clip(0);
    }
    void _OnDamageUpdate(DamageEvent e)
    {
        play_clip(1);
    }
    void _OnLevelUp(LevelUpEvent e)
    {
        play_clip(2);
    }
    void _OnLurkerEvent(LurkerEvent e)
    {
        play_clip(3); 
    }
    void _OnWitchEvent(WitchEvent e)
    {
        play_clip(4);
    }
    public void play_clip(int n)
    {
        AudioSource.PlayClipAtPoint(clips[n], Camera.main.transform.position);
    }
    private void OnDestroy()
    {
        EventBus.Unsubscribe(damage_event_subscription);
        EventBus.Unsubscribe(collision_event_subscription);
        EventBus.Unsubscribe(level_up_event_subscription);
        EventBus.Unsubscribe(lurker_event_subscription); 
    }
}

