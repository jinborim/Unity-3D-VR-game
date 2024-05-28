using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Checking : MonoBehaviour
{
    [SerializeField]
    static Inventory theinventory;
    static Slot[] slots;
    static Read_Slot[] read_slot;
    public static bool is_exist=false;

    // Start is called before the first frame update
    void Start()
    {
        theinventory = GameObject.FindObjectOfType<Inventory>();
        read_slot = theinventory.Read_SlotParent.GetComponentsInChildren<Read_Slot>();
        slots= theinventory.Item_SlotParent.GetComponentsInChildren<Slot>();
    }

    // 간단하게 인벤토리에 해당 아이템이 있는지 확인
    public static bool InventoryChecking(Item item)
    {
        is_exist = false;
        for(int i=0; i<slots.Length; i++)
        {
            if (slots[i].item == item)
            {
                is_exist = true;
                
                break;
            }
        }

        return is_exist;
    }

    //인벤토리에서는 static으로 참조하지 않아서 여기에 만듦
    public static bool Item_Use(Item item)
    {
        is_exist = false;
        for (int i=0; i<slots.Length; i++)
        {
            if (slots[i].item == item)
            {
                is_exist = true;
                StaticCoroutine.Start(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().Item_Use_Text, new string[] { slots[i].item.itemName + "을(를) 사용했다." }, "N"));
                slots[i].SetSlotCount(-1);
                break;
            }
        }
        return is_exist;
    }

    public static bool Read_Use(Item item)
    {
        is_exist = false;
        for (int i = 0; i < read_slot.Length; i++)
        {

            if (read_slot[i].item == item)
            {
                is_exist = true;
                //StaticCoroutine.Start(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().Item_Use_Text, new string[] { slots[i].item.itemName + "을(를) 사용했다." }, "N"));
                read_slot[i].ClearSlot();
                break;
            }
        }
        return is_exist;
    }


}
