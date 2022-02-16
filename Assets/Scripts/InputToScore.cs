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

    //void _OnScoreUpdated(ScoreEvent e)
    //{
    //    Debug.Log("enemy died");
    //}
    void _OnScoreUpdated(ScoreEvent e)
    {
        total_score += e.new_score;
        text_component.text = "Score : " + total_score;
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