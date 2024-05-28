using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    public string ChatText = "";
    private GameObject Main;
    void Start()
    {
        Main = GameObject.Find("ClickScript");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Character")
        {
            Main.GetComponent<Script_igame>().NPCChatEnter(ChatText);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Character")
        {
            Main.GetComponent<Script_igame>().NPCChatExit();
        }
    }
}
