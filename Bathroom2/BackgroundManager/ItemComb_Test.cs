using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComb_Test : MonoBehaviour
{
    public Combinationable comb;
    public Description_base Desc;
    public Inventory theInventory;

    public ITEM_LIST item_list;
    public Item result_item;



    // Start is called before the first frame update
    void Start()
    {
        Desc = GameObject.FindObjectOfType<Description_base>();
        theInventory = GameObject.FindObjectOfType<Inventory>();
        item_list = GetComponent<ITEM_LIST>();
        
    }

    public Item Item_Combination(Item item_one, Item Item_two)
    {
        //Debug.Log(item_one.name+" 와 "+ Item_two.name);
        switch (item_one.itemName) //합성하려는 아이템 1
        {
            case "Red":
                switch (Item_two.itemName)
                {
                    case "Blue":
                        Combed_Item_Compare("Purple");
                        //Debug.Log(result_item.name);
                        theInventory.AcquireItem(result_item);
                        break;
                }
                break;
            case "Blue":
                switch (Item_two.itemName)
                {
                    case "Red":
                        Combed_Item_Compare("Purple");
                        //Debug.Log(result_item.name);
                        theInventory.AcquireItem(result_item);
                        break;
                }
                break;
            case "Wastepaper":
                switch (Item_two.itemName)
                {
                    case "Knif":
                        Combed_Item_Compare("Hint");
                        //Debug.Log(result_item.name);
                        theInventory.AcquireItem(result_item);
                        break;
                }
                break;
            case "Knif":
                switch (Item_two.itemName)
                {
                    case "Wastepaper":
                        Combed_Item_Compare("Hint");
                        //Debug.Log(result_item.name);
                        theInventory.AcquireItem(result_item);
                        break;
                }
                break;
            case "Purple":
                switch (Item_two.itemName)
                {
                    case "Capsule":
                        Combed_Item_Compare("Key");
                        //Debug.Log(result_item.name);
                        theInventory.AcquireItem(result_item);
                        break;
                }
                break;
            case "Capsule":
                switch (Item_two.itemName)
                {
                    case "Purple":
                        Combed_Item_Compare("Key");
                        //Debug.Log(result_item.name);
                        theInventory.AcquireItem(result_item);
                        break;
                }
                break;
        }
        return result_item;
    }

    public void Combed_Item_Compare(string item_name)
    {
        for(int i=0; i<item_list.items.Length; i++)
        {
            if (item_name == item_list.items[i].itemName)
            {
                result_item = item_list.items[i];
                break;
            }
            else
            {
                result_item = null;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
