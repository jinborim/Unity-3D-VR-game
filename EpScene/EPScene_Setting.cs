using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPScene_Setting : MonoBehaviour
{
    public GameObject character;
    public GameObject UI_Group;
    // Start is called before the first frame update
    void Start()
    {
        if (character == null)
        {
            character = GameObject.Find("head");
        }
        character.gameObject.SetActive(false);

        if (UI_Group == null)
        {
            UI_Group = GameObject.Find("UI_Group");
        }
        UI_Group.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
