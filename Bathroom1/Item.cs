using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="New Item/item")]

public class Item : ScriptableObject
{
    
    public enum ItemType
    {
        Normal, //일반
        Read, //읽기전용(책이나 서류)
        Comb, //조합
        Decomp //분해
    }

    public string itemName;
    public ItemType itemType;
    public Sprite ItemImage; // 인벤토리 내 아이템 이미지
    public GameObject itemPrefab; // 아이템 프리팹
    [TextArea]
    public string item_exp;
    public bool Usable;

}
