using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_AudioClip_Manager : MonoBehaviour
{
    [SerializeField]
    public AudioSource Move_Audio_Source;
    [SerializeField]
    public AudioSource Line_Audio_Source;
    [SerializeField]
    public AudioSource Sound_Audio_Source;

    public AudioClip monster_walk;
    public AudioClip monster_growl1;
    public AudioClip monster_growl2;
    public AudioClip monster_line1;
    public AudioClip monster_line2;
    public AudioClip monster_line3;
    public AudioClip monster_line4;

    public void M_Effect_Sound(string audio_name)
    {
        switch (audio_name)
        {
            case "MWalk":
                Move_Audio_Source.PlayOneShot(monster_walk);
                break;
            case "Growl1":
                Sound_Audio_Source.PlayOneShot(monster_growl1);
                break;
            case "Growl2":
                Sound_Audio_Source.PlayOneShot(monster_growl2);
                break;
        }
    }

    public void M_Line_Sound(string audio_name)
    {
        switch (audio_name)
        {
            case "Growl":
                Line_Audio_Source.PlayOneShot(monster_growl1);
                break;
            case "Line1":
                Line_Audio_Source.PlayOneShot(monster_line1);
                break;
            case "Line2":
                Line_Audio_Source.PlayOneShot(monster_line2);
                break;
            case "Line3":
                Line_Audio_Source.PlayOneShot(monster_line3);
                break;
            case "Line4":
                Line_Audio_Source.PlayOneShot(monster_line4);
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
