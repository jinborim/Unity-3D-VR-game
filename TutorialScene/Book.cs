using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Book : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    string[] message = new string[] { };
    [SerializeField]
    GameObject addable_Item;
    public Inventory theInventory;
    [SerializeField]
    bool need_check;

    public bool book_Checked=false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if ((eventData.button == PointerEventData.InputButton.Right))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.name == "Book")
            {
                StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, message, "N"));
                if (addable_Item != null)
                {
                    if (addable_Item.GetComponent<ItemPickup>().item.itemType == Item.ItemType.Read)
                    {
                        
                        theInventory.Temp_Readable_Text(addable_Item.GetComponent<Readable>().Read_Text);
                    }
                    theInventory.AcquireItem(addable_Item.GetComponent<ItemPickup>().item);
                }
                else
                {
                    //Debug.Log("딱히 아이템 없음");
                }
            }

            if (need_check == true)
            {
                book_Checked = true;
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
