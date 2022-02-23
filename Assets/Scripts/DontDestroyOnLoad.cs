using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DontDestroyOnLoad : MonoBehaviour
{
    Subscription<MainMenuEvent> main_menu_event_subscription; 
    // Start is called before the first frame update
    void Start()
    {
        main_menu_event_subscription  = EventBus.Subscribe<MainMenuEvent>(_onMainMenu); 
        DontDestroyOnLoad(this.gameObject);
    }

    void _onMainMenu(MainMenuEvent e) {
        SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(main_menu_event_subscription);
    }
}
