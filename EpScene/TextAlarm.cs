using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextAlarm : MonoBehaviour
{
    [SerializeField]
    public Text textR;
    

    private void Start()
    {
        textR.gameObject.SetActive(false);
        
    }

}
