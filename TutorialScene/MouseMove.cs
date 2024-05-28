using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public float sensitivity = 500f;
    public float rotationX;
    public float rotationY;

    public static bool mouse_able=true;

    // Start is called before the first frame update
    void Start()
    {
        mouse_able = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Inventory.invectoryActivated == false)&&(mouse_able==true)) // 인벤토리가 켜져있지 않고 마우스를 움직여도 될 때
        {
            float mouseMoveX = Input.GetAxis("Mouse X");
            float mouseMoveY = Input.GetAxis("Mouse Y");

            rotationY += mouseMoveX * sensitivity * Time.deltaTime;
            rotationX += mouseMoveY * sensitivity * Time.deltaTime;

            if (rotationX > 80f)
            {
                rotationX = 80f;
            }
            if (rotationX < -80f)
            {
                rotationX = -80f;
            }
            transform.eulerAngles = new Vector3(-rotationX, rotationY, 0);
        }

        


    }
}
