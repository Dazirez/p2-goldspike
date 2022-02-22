using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour { 

    public Image abilityImage;
    private float cooldown;
    public int abilitynumber; 
    bool isCoolDown = false;
    public KeyCode ability; 
    // Start is called before the first frame update
    void Start()
    {
        abilityImage.fillAmount = 0;
        cooldown = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerControls>().cooldown_durations[abilitynumber];
    }

    // Update is called once per frame
    void Update()
    {
        Ability1(); 
    }
    void Ability1()
    {
        if(Input.GetKey(ability) && isCoolDown == false)
        {
            isCoolDown = true;
            abilityImage.fillAmount = 1; 
        }
        if(isCoolDown)
        {
            abilityImage.fillAmount -= 1 / cooldown * Time.deltaTime;
            if(abilityImage.fillAmount <= 0)
            {
                abilityImage.fillAmount = 0;
                isCoolDown = false; 
            }
        }
    }
}
