using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    Subscription<CollisionEvent> collision_event_subscription;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        collision_event_subscription = EventBus.Subscribe<CollisionEvent>(_OnCollisionUpdated);

    }
    void _OnCollisionUpdated(CollisionEvent e)
    {
        CameraShaker.Instance.ShakeOnce(4f, 20f, 0.1f, 1f); 
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

}
