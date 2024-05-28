using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMg_Maintain : MonoBehaviour
{

    public static SoundMg_Maintain Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
