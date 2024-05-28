using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackBtn : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image btnImg;
    public Vent vent;
    public Inventory theInventory;

    public Effect_AudioClip_Manager EAM;

    public int count=0;

    public void OnPointerEnter(PointerEventData eventData)
    {
        btnImg.color = new Color32(255, 255, 255, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        btnImg.color = new Color32(255, 255, 255, 0);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //모든 움직임 정지 해제
            Movement_Controll.Move_Stop();

            theInventory.AcquireItem(vent.lockKey.Key);
            count = 0;
            btnImg.color = new Color32(255, 255, 255, 0);
            SceneManager.UnloadSceneAsync("Vent");
        }
    }

    public void TryOpen_vent()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (count >= 20)
            {
                
                //모든 움직임 정지 해제
                Movement_Controll.Move_Start();

                vent.Vent_Opened();
                SceneManager.UnloadSceneAsync("Vent");
            }
            else
            {
                EAM.Effect_Sound("Vent");
                count += 1;
            }
            
        }
    }

   


    // Start is called before the first frame update
    void Start()
    {
        // 모든 움직임 멈춤
        Movement_Controll.Move_Stop();

        EAM = GameObject.FindObjectOfType<Effect_AudioClip_Manager>();
        btnImg = GetComponent<Image>();
        vent = GameObject.FindObjectOfType<Vent>();
        theInventory = GameObject.FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        TryOpen_vent();
    }
}
