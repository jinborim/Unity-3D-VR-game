using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_AudioClip_Manager : MonoBehaviour
{
    [SerializeField]
    public AudioSource Audio_Source;

    public AudioClip walk;
    public AudioClip Cabinet_Locked;
    public AudioClip Cabinet_Open;
    public AudioClip Cabinet_Close;
    public AudioClip access_denied;
    public AudioClip aceess;
    public AudioClip LockedDoor;
    public AudioClip Unlock;
    public AudioClip Locked_Vent;
    public AudioClip OpenVent;
    public AudioClip Glass;


    public void Effect_Sound(string audio_name)
    {
        switch (audio_name)
        {
            case "WAlk":
                Audio_Source.PlayOneShot(walk);
                break;
            case "CabinetLocked":
                Audio_Source.PlayOneShot(Cabinet_Locked);
                break;
            case "CabinetOpen":
                Audio_Source.PlayOneShot(Cabinet_Open);
                break;
            case "CabinetClose":
                Audio_Source.PlayOneShot(Cabinet_Close);
                break;
            case "AccessDeny":
                Audio_Source.PlayOneShot(access_denied);
                break;
            case "Access":
                Audio_Source.PlayOneShot(aceess);
                break;
            case "LockedDoor":
                Audio_Source.PlayOneShot(LockedDoor);
                break;
            case "Unlock":
                Audio_Source.PlayOneShot(Unlock);
                break;
            case "Vent":
                Audio_Source.PlayOneShot(Locked_Vent);
                break;
            case "VentOpen":
                Audio_Source.PlayOneShot(OpenVent);
                break;
            case "Glass":
                Audio_Source.PlayOneShot(Glass);
                break;
        }
        
    }

}
