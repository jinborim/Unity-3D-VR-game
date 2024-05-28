using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CabinetOpen : MonoBehaviour, IPointerClickHandler
{
    public GameObject CurrentDoor;

    
    public float moveSpeed = 3;

    public bool is_activated=false;
    public bool is_locked;

    public Material[] mat=new Material[2];

    string[] message =new string[1];


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
        message = new string[] { "잠겨있다.", "키패드에 번호를 입력해야 할 거 같다." };
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.name == "door")
            {
                if(is_locked != true)
                {
                    //Debug.Log("터치된 오브젝트: " + hit.transform.name);
                    if (is_activated == false)
                    {
                        //this.gameObject.GetComponent<MeshRenderer>().material = mat[0];
                        //StartCoroutine(Open_Door());
                        hit.transform.gameObject.GetComponent<CabinetOpen>().Open_Door();
                        
                        is_activated = true;
                    }

                    else if (is_activated == true)
                    {
                        //this.gameObject.GetComponent<MeshRenderer>().material = mat[1];
                        //StartCoroutine(Close_Door());
                        hit.transform.gameObject.GetComponent<CabinetOpen>().Close_Door();
                        
                        is_activated = false;
                    }
                }
                else if (is_locked == true)
                {
                    
                    EAM.Effect_Sound("CabinetLocked");
                    StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, message, "N"));



                }

                

            }

        }
    }

    public void Open_Door()
    {
        EAM.Effect_Sound("CabinetOpen");
        CurrentDoor.transform.rotation = Quaternion.Euler(0, -75, 0);
        
    }
    public void Close_Door()
    {
        EAM.Effect_Sound("CabinetClose");
        CurrentDoor.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void Unlock_Door()
    {
        EAM.Effect_Sound("Unlock");
        StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "문이 열렸다." }, "N"));
        is_locked = false;
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
