using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    Subscription<CollisionEvent> collision_event_subscription;
    Subscription<DamageEvent> damage_event_subscription;

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

    }
    void _OnCollisionUpdated(CollisionEvent e)
    {
        AudioSource.PlayClipAtPoint(clips[0], Camera.main.transform.position);
    }
    void _OnDamageUpdate(DamageEvent e)
    {
        AudioSource.PlayClipAtPoint(clips[1], Camera.main.transform.position);

    }
    public void play_clip(int n)
    {
        AudioSource.PlayClipAtPoint(clips[n], Camera.main.transform.position);
    }
    private void OnDestroy()
    {
        EventBus.Unsubscribe(damage_event_subscription);
        EventBus.Unsubscribe(collision_event_subscription);

    }
}

