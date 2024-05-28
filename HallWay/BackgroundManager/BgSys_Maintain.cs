using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSys_Maintain : MonoBehaviour
{

    public static BgSys_Maintain Instance;

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
