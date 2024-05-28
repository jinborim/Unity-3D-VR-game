using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clock : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    public int time;
    string[] message = new string[] { };

    public void OnPointerClick(PointerEventData eventData)
    {
        if ((eventData.button == PointerEventData.InputButton.Right))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && ((hit.transform.name == "DigitalClock")|| (hit.transform.name == "TableClock") || (hit.transform.name == "WallClock")))
            {
                StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, message, "N"));
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        message = new string[] {"멈춰있는 시계다.", "시간은 "+time+"시를 가리키고 있다." };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
