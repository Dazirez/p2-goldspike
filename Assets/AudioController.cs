using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    public AudioClip[] clips;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void play_clip(int n)
    {
        AudioSource.PlayClipAtPoint(clips[n], Camera.main.transform.position);
    }
}
