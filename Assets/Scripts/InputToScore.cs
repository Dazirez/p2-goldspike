using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputToScore : MonoBehaviour
{
    Subscription<ScoreEvent> death_event_subscription;
    public int total_score = 0;

    TMP_Text text_component;
    // Start is called before the first frame update
    void Start()
    {
        death_event_subscription = EventBus.Subscribe<ScoreEvent>(_OnScoreUpdated);
        text_component = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        text_component.text = "Score : " + total_score;

    }
    void _OnScoreUpdated(ScoreEvent e)
    {
        total_score += e.new_score;
        text_component.text = "Score : " + total_score;
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(death_event_subscription);
    }
}