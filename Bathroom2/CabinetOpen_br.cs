using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CabinetOpen_br : MonoBehaviour, IPointerClickHandler
{
    public GameObject CurrentDoor;


    public float moveSpeed = 3;

    public bool is_activated = false;
    public bool is_locked;

    public Material[] mat = new Material[2];

    string[] message = new string[1];


    public Inventory_Checking invenCheck;
    public Effect_AudioClip_Manager EAM;

    [SerializeField]
    KEY lockKey;


    // Start is called before the first frame update
    void Start()
    {
        CurrentDoor = this.transform.gameObject;
        invenCheck = GameObject.FindObjectOfType<Inventory_Checking>();
        EAM = GameObject.FindObjectOfType<Effect_AudioClip_Manager>();
        message = new string[] { "잠겨있는 듯 하다." };
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.name == "door")
            {
                if (is_locked != true)
                {
                    if (is_activated == false)
                    {
                        hit.transform.gameObject.GetComponent<CabinetOpen_br>().Open_Door();
                        EAM.Effect_Sound("CabinetOpen");
                        is_activated = true;
                    }

                    else if (is_activated == true)
                    {
                        hit.transform.gameObject.GetComponent<CabinetOpen_br>().Close_Door();
                        EAM.Effect_Sound("CabinetClose");
                        is_activated = false;
                    }
                }
                else if (is_locked == true)
                {
                    if (Inventory_Checking.InventoryChecking(lockKey.Key) == true)
                    {
                        EAM.Effect_Sound("Unlock");
                        StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "문이 열렸다." }, "N"));
                        is_locked = false;
                    }
                    else if (Inventory_Checking.InventoryChecking(lockKey.Key) != true)
                    {
                        EAM.Effect_Sound("CabinetLocked");
                        StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, message, "N"));
                    }

                }

            }

        }
    }

    public void Open_Door()
    {
        CurrentDoor.transform.rotation = Quaternion.Euler(0, -75, 0);
    }
    public void Close_Door()
    {
        CurrentDoor.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {


    }
}
