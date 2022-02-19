using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour { 

    [Header("Ability 1")]
    public Image abilityImage1;
    public float cooldown1;
    bool isCoolDown = false;
    public KeyCode ability1; 
    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        Ability1(); 
    }
    void Ability1()
    {
        if(Input.GetKey(ability1) && isCoolDown == false)
        {
            isCoolDown = true;
            abilityImage1.fillAmount = 1; 
        }
        if(isCoolDown)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            if(abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCoolDown = false; 
            }
        }
    }
}
