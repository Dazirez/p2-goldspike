using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputToHealth : MonoBehaviour
{
    Subscription<DamageEvent> damage_event_subscription;
    public int total_score = 0;

    TMP_Text text_component;
    // Start is called before the first frame update
    void Start()
    {
        damage_event_subscription = EventBus.Subscribe<DamageEvent>(_OnDamageUpdate);
        text_component = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        text_component.text = "Health : " + GameController.instance.health;

    }

    //void _OnScoreUpdated(ScoreEvent e)
    //{
    //    Debug.Log("enemy died");
    //}
    void _OnDamageUpdate(DamageEvent e)
    {
        
        text_component.text = "Health : " + GameController.instance.health;
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(damage_event_subscription);
    }
}