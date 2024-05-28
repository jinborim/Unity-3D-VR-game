using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Candle : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject book;
    [SerializeField]
    Item paper;
    [SerializeField]
    GameObject Changed_paper;
    [SerializeField]
    Inventory theInventory;
    public GameObject Flame;
    public KEY lockKey;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.name == "Candle")
            {
                if (Inventory_Checking.Item_Use(lockKey.Key) == true)
                {
                    //Inventory_Checking.Item_Use(lockKey.Key);
                    StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "양초에 불을 붙였다." }, "N"));
                    Flame.gameObject.SetActive(true);
                }
                else
                {
                    if (Flame.activeSelf == true)
                    {
                        if ((book.GetComponent<Book>().book_Checked == true)&&(Inventory_Checking.Read_Use(paper)==true))
                        {
                            Text_Effect.type(new string[] { "불이 타오르고 있다...","...","어쩌면 여기에 노란 종이를 갖다대면 될지도 모르겠다." }, "D");
                            theInventory.Temp_Readable_Text(Changed_paper.GetComponent<Readable>().Read_Text);
                            theInventory.AcquireItem(Changed_paper.GetComponent<ItemPickup>().item);
                        }
                        else
                        {
                            Text_Effect.type(new string[] { "불이 타오르고 있다..." }, "N");
                        }
                        
                    }
                    else
                    {
                        Text_Effect.type(new string[] { "왜 이런 곳에 양초가 있지..." }, "N");
                    }
                    
                }
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        Flame.gameObject.SetActive(false);
        lockKey = GetComponent<KEY>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
