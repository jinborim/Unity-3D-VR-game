using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSound_Manager : MonoBehaviour
{
    public AudioSource Effect_source;
    public AudioClip walk;
    public AudioClip Glass;
    //public AudioClip effect_clip;

    // Start is called before the first frame update
    void Start()
    {
        Effect_source = GetComponent<AudioSource>();

    }

    static public void Play_EffectSound(AudioClip audio_clip)
    {
        //Effect_source.PlayOneShot(audio_clip);
    }

    public void Play_WalkSound(string audio_name)
    {
        switch (audio_name)
        {
            case "Walk":
                Effect_source.PlayOneShot(walk);
                break;
            case "Glass":
                Effect_source.PlayOneShot(Glass);
                break;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
