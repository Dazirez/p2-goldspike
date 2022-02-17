using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    DashAttack attack1;
    Movement mv;
    Rigidbody rb; 
    bool busy = false;
    public float dash_attack_force = 40f; 
    // Update is called once per frame
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        attack1 = GetComponent<DashAttack>();
        mv = GetComponent<Movement>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !busy)
        {
            //attack1.Attack();
            StartCoroutine(dashattack());
        }
        if (Input.GetKeyDown(KeyCode.X) && !busy)
        {
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
        yield return new WaitForSeconds(1.0f);
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

        yield return new WaitForSeconds(0.25f);
        busy = false;

    }
}
