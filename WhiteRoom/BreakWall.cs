using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BreakWall : MonoBehaviour, IPointerClickHandler
{
    //public string[] message;
    public Inventory_Checking invenCheck;

    [SerializeField]
    public AXE axe;

    //public Door door;

    public GameObject Brokenwall;

    public Effect_AudioClip_Manager EAM;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;



            if (Physics.Raycast(ray, out hit) && hit.transform.name == "BreakHere")
            {

                if (Inventory_Checking.InventoryChecking(axe.Axe) == true)
                {
                    EAM.Effect_Sound("breakingwindow");
                    StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "거울이 깨졌다. 깨진 거울 뒤로 공간이 보인다." }, "N"));
                    Brokenwall.SetActive(false);
                    //GameObject.FindObjectOfType<Puzzle_touch>().Puzzle.SetActive(false);

                    //door.is_locked = false;
                }
                else if (Inventory_Checking.InventoryChecking(axe.Axe) != true)
                {
                    //StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "평범해 보이는 컴퓨터.", "옆의 홈에 뭔가 끼울 수 있을 것 같다..." }, "N"));
                }
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        invenCheck = GameObject.FindObjectOfType<Inventory_Checking>();
        //door = GameObject.FindObjectOfType<Door>();
        EAM = GameObject.FindObjectOfType<Effect_AudioClip_Manager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
