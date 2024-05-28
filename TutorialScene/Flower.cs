using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Flower : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    bool is_scent;
    [SerializeField]
    public int count;
    string[] message = new string[] { };

    public void OnPointerClick(PointerEventData eventData)
    {
        if ((eventData.button == PointerEventData.InputButton.Right))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && ((hit.transform.name == "Rose") || (hit.transform.name == "Flower")))
            {
                StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, message, "N"));
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (is_scent == true)
        {
            message = new string[] { "이런 곳에 웬 꽃이지...", "향기롭다.", "꽃은 " + count + "송이다." };
        }
        else
        {
            message = new string[] { "꽃이다. ", "자세히 보니 조화인듯 하다.", count + "송이다." };
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
