using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMaintain : MonoBehaviour
{
    public static CharacterMaintain Instance;

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
