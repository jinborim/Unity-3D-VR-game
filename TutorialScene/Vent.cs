using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Vent : MonoBehaviour, IPointerClickHandler
{
    private Door door;
    private Boxes box;
    private Special_Box special_box;
    public bool Vent_check=false;

    [SerializeField]
    public KEY lockKey;
    public Inventory_Checking invenCheck;

    public Effect_AudioClip_Manager EAM;

    public int Dialogue_Count=0;

    public void OnPointerClick(PointerEventData eventData)
    {
        if ((eventData.button == PointerEventData.InputButton.Right)&&(Text_Effect.is_text==false))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.name == "Vent")
            {

                if (door.door_check == true && box.box_check == false)
                {
                    StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "잠긴 문 대신 여기로 나갈 수 있을지도 모르겠다." }, "N"));
                    Vent_check = true;
                }
                else if (door.door_check && box.box_check == true)
                {
                    special_box = GameObject.FindObjectOfType<Special_Box>();
                    //키가 있는 경우
                    if (Inventory_Checking.InventoryChecking(lockKey.Key) == true)
                    {
                        // 박스에 올라갔을 때만 작동
                        if (special_box.OnBox != true)
                        {
                            StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "너무 높아서 여기서는 손이 닿지 않는다." }, "N"));
                        }
                        else if (special_box.OnBox == true)
                        {
                            if(Dialogue_Count == 0)
                            {
                                StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "이 드라이버라면 문을 열 수 있을 것 같다.", "Z 키를 연타해서 드라이버를 사용하자" }, "N"));
                                Dialogue_Count += 1;
                            }
                            
                            Inventory_Checking.Item_Use(lockKey.Key);
                            //여기에 벤트 여는 함수
                            SceneManager.LoadScene("Vent", LoadSceneMode.Additive);
                        }
                    }
                    else if (Inventory_Checking.InventoryChecking(lockKey.Key) != true) // 키가 없는 경우
                    {
                        if (special_box.OnBox != true)
                        {
                            StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "너무 높아서 여기서는 손이 닿지 않는다." }, "N"));
                        }
                        else if (special_box.OnBox == true)
                        {
                            StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "환풍구를 열만한 도구가 필요할 것 같다." }, "N"));
                        }
                    }
                }
                else
                {
                    StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "낡은 환풍구인 것 같다.", "너무 높아서 손이 닿을 것 같지 않다." }, "N"));
                }
            }
        }

        
    }

    public void Vent_Opened()
    {
        EAM.Effect_Sound("VentOpen");
        Text_Effect.type(new string[] { "문이 열렸다" }, "N");
        GameObject.FindObjectOfType<Hole>().hole.SetActive(true);
        gameObject.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        Dialogue_Count = 0;
        door = GameObject.FindObjectOfType<Door>();
        box = GameObject.FindObjectOfType<Boxes>();
        invenCheck = GameObject.FindObjectOfType<Inventory_Checking>();
        EAM = GameObject.FindObjectOfType<Effect_AudioClip_Manager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
