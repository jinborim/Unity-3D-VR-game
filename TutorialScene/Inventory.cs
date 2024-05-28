using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //public static GameObject INVENTORY;
    public static bool invectoryActivated = false;

    [SerializeField]
    private GameObject go_InventoryBase; //Inventory의 베이스가 되는 이미지(검은 바탕)
    [SerializeField]
    public GameObject Item_SlotParent;
    [SerializeField]
    public GameObject Read_SlotParent;
    [SerializeField]
    public Description_base Desc;

    [SerializeField]
    public CombBtn comb;
    private Alarm alarm;

    private Slot[] slots;
    private Read_Slot[] read_Slots;

    public string Temp_Text;
    public static bool inventory_able=true;

    // Start is called before the first frame update
    void Start()
    {
        inventory_able = true;
        go_InventoryBase.SetActive(false);
        slots = Item_SlotParent.GetComponentsInChildren<Slot>();
        read_Slots=Read_SlotParent.GetComponentsInChildren<Read_Slot>();
        //comb = GameObject.FindObjectOfType<CombBtn>();
        alarm = GameObject.FindObjectOfType<Alarm>();
    }

    private void TryOpenInventory()
    {
        if ((alarm.is_alarm != true)&&(inventory_able==true))
        {
            if (Input.GetKeyDown(KeyCode.I)) //일단은 I키로
            {
                invectoryActivated = !invectoryActivated;

                if (invectoryActivated)
                {
                    OpenInventory();


                }

                else
                {

                    //Desc.DSC_Base.SetActive(false);
                    CloseInventory();
                }


            }
        }
        
    }

    private void OpenInventory()
    {
        InventoryReset();
        go_InventoryBase.SetActive(true);
        Read_SlotParent.SetActive(false);
        
    }

    private void CloseInventory()
    {
        if ((go_InventoryBase.activeSelf == true))
        {
            go_InventoryBase.SetActive(false);
        }
        Desc.DSC_Base.SetActive(false);

    }

    public void InventoryReset()
    {
        //인벤토리 관련된 모든 기능 한 번 리셋
        if (Item_SlotParent.activeSelf == false)
        {
            Item_SlotParent.SetActive(true);
        }
        if (comb!=null&&comb.is_Comb == true)
        {
            comb.is_Comb = false;
            comb.UnlockCombinationMode();
        }
    }


    // Update is called once per frame
    void Update()
    {
        TryOpenInventory();
    }

    public void Temp_Readable_Text(string text)
    {
        Temp_Text = null;
        Temp_Text = text;
    }


    public void AcquireItem(Item _item, int _count = 1)
    {
        //Debug.Log("아이템 휙득");

        if (_item.itemType != Item.ItemType.Read)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)  // null 이라면 slots[i].item.itemName 할 때 런타임 에러 나서
                {
                    if (slots[i].item.itemName == _item.itemName) // 모든 슬롯을 검사해서 어떤 슬롯에 새 아이템과 같은 종류의 아이템이 있을때..
                    {
                        slots[i].SetSlotCount(_count); //현재 _count=1이므로 slot의 SetSlotCount에서 아이템 카운트를 1만큼 새로 올려줌
                        return;
                    }
                }
                else if (slots[i].item == null)//앞의 슬롯부터 차례로 검사해서 빈 슬롯이 있을 때
                {
                    slots[i].AddItem(_item, _count); // 해당 슬롯에 아이템을 넣어줌
                    return;
                }

            }
        }
        else if(_item.itemType == Item.ItemType.Read)
        {
            for(int j=0; j<read_Slots.Length; j++)
            {
                if (read_Slots[j].item == null)
                {
                    read_Slots[j].AddItem(_item);
                    read_Slots[j].Get_Text(Temp_Text);
                    return;
                }
            }
        }

        
        


    }



}
