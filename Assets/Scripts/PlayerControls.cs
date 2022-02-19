using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Movement mv;
    Rigidbody rb; 
    bool busy = false;

    public float dash_attack_force = 40f;

    public float[] timers;
    public float[] cooldown_durations;

    // Update is called once per frame
    private void Start()
    {
        mv = GetComponent<Movement>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        for(int i = 0; i < timers.Length; i++)
        {
            timers[i] -= Time.deltaTime; 
        }
        if(Input.GetKeyDown(KeyCode.Space) && !busy && timers[0] < 0)
        {

            timers[0] = cooldown_durations[0];

            //attack1.Attack();
            StartCoroutine(dashattack());
        }
        if (Input.GetKeyDown(KeyCode.X) && !busy && timers[1] < 0)
        {

            timers[1] = cooldown_durations[1]; 
            //attack1.Attack();
            StartCoroutine(swordattack());
        }
    }

    IEnumerator dashattack()
    {
        Vector2 direction = mv.GetDirection().normalized; 
        busy = true;
        mv.enabled = false;
        rb.velocity = -direction * 10.0f;
        yield return new WaitForSeconds(0.2f);
        transform.Find("dashattack").gameObject.SetActive(true); 

        EventBus.Publish<DashEvent>(new DashEvent());
        rb.velocity = direction * dash_attack_force;
        yield return new WaitForSeconds(0.1f);
        transform.Find("dashattack").gameObject.SetActive(false);
        rb.velocity = Vector2.zero;
        mv.enabled = true;
        busy = false;

    }
    IEnumerator swordattack()
    {
        busy = true;
        mv.enabled = false;
        rb.velocity = Vector2.zero;
        transform.Find("swordattack").gameObject.SetActive(true);
        EventBus.Publish<SwordSwingEvent>(new SwordSwingEvent());

        yield return new WaitForSeconds(0.2f);
        transform.Find("swordattack").gameObject.SetActive(false);
        mv.enabled = true;
        rb.velocity = Vector2.zero;
        busy = false;
    }
}
