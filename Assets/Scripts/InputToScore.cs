using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputToScore : MonoBehaviour
{
    Subscription<LevelUpEvent> level_event_subscription;

    public int level = 1; 
    TMP_Text text_component;
    // Start is called before the first frame update
    void Start()
    {
        level_event_subscription = EventBus.Subscribe<LevelUpEvent>(_OnLevelUpdated);
        text_component = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        text_component.text = "Level " + level;

    }
    void _OnLevelUpdated(LevelUpEvent e)
    {
        level = e.level;
        text_component.text = "Level " + e.level;
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(level_event_subscription);
    }
}