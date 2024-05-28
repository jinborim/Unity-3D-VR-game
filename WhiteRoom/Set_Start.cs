using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Start : MonoBehaviour
{
    public float Xpoint;
    public float Ypoint;
    public float Zpoint;

    public GameObject character;
    public Vector3 start_transform;

    // Start is called before the first frame update
    void Start()
    {
        

        start_transform = new Vector3(Xpoint, Ypoint, Zpoint);
        if (character == null)
        {
            character = GameObject.Find("head");
        }
        character.transform.position = start_transform;
        
        // 쫓길때만 잠깐 속도 바꿔주는 용도

        //character.GetComponent<CharacterMovement>().moveSpeed = 50f;
        //character.GetComponent<CharacterMovement>().jumpSpeed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
