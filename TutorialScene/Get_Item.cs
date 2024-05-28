using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;

public class Get_Item : MonoBehaviour
{
    [SerializeField]
    private Inventory theInventory;

   
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("Item"))
            {
                
                // 아이템을 슬롯으로 보내는 작업
                if (hit.transform.GetComponent<ItemPickup>().item != null)
                {
                    if (hit.transform.GetComponent<ItemPickup>().item.itemType == Item.ItemType.Read)
                    {
                        theInventory.Temp_Readable_Text(hit.transform.GetComponent<Readable>().Read_Text);
                    }
                    theInventory.AcquireItem(hit.transform.GetComponent<ItemPickup>().item);
                    
                    Destroy(hit.transform.gameObject);
                }
                else
                {
                    Debug.Log("아이템");
                }


            }
        }
    }
}
