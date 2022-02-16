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

    //void _OnScoreUpdated(ScoreEvent e)
    //{
    //    Debug.Log("enemy died");
    //}
    void _OnDamageUpdate(DamageEvent e)
    {
        Debug.Log("health is: " + GameController.instance.health);
        text_component.text = "Health : " + GameController.instance.health;
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if (inventory != null && text_component != null)
    //    {
    //        text_component.text = ": " + inventory.GetBombs().ToString();
    //    }
    //}
}