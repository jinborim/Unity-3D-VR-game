using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Door : MonoBehaviour, IPointerClickHandler
{
    public GameObject DOOR;
    public bool door_check=false;

    public Effect_AudioClip_Manager EAM;

    public void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.name == "Locked_Door")
            {
                EAM.Effect_Sound("LockedDoor");
                StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "문은 열리지 않는다." },"N"));
                door_check = true;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        EAM = GameObject.FindObjectOfType<Effect_AudioClip_Manager>();
        door_check = false;
    }

    public void Open_Door()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
