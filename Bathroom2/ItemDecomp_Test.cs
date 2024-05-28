using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDecomp_Test : MonoBehaviour
{
    public decompositionable decomp;
    public Inventory theinventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Item_Decomposition(Item item)
    {
        decomp=item.itemPrefab.GetComponent<decompositionable>();
        for(int i=0; i<decomp.decomposition_result_Item.Length; i++)
        {
            theinventory.AcquireItem(decomp.decomposition_result_Item[i].transform.GetComponent<ItemPickup>().item);
        }
    }

}
