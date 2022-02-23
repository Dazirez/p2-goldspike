using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiyMonitor : MonoBehaviour
{
    Subscription<LevelUpEvent> level_up_event_subscription;
    private int num_unlocked = 1; 
    // Start is called before the first frame update
    void Start()
    {
        level_up_event_subscription = EventBus.Subscribe<LevelUpEvent>(_OnLevelUp);

    }

    void _OnLevelUp(LevelUpEvent e)
    {
        
        if(e.isBreakpoint)
        {
            unlockNext(); 
        }
    }

    void unlockNext() {
        if(num_unlocked == 1)
        {
            transform.Find("Attack2").gameObject.SetActive(true);

        }
        else if(num_unlocked == 2)
        {
            transform.Find("Attack3").gameObject.SetActive(true);

        }
        num_unlocked++; 
    }
    private void OnDestroy()
    {
        EventBus.Unsubscribe(level_up_event_subscription);
    }
}
