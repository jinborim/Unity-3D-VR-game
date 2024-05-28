using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Boxes : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject box_prefab;
    private Vent vent_checking;
    public bool box_check=false;
    [SerializeField]
    private GameObject[] invisibleBoxes;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.name == "Box")
            {
                if (vent_checking.Vent_check == true)
                {
                    StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "박스 더미이다.", "....", "이들을 옮기면 환풍구에 손이 닿을 것 같다." }, "D"));
                    //StartCoroutine(Faded.Desolving());
                    for(int i=0; i < invisibleBoxes.Length; i++)
                    {
                        Destroy(invisibleBoxes[i].gameObject,4.8f);
                    }
                    StartCoroutine(box_make());
                    box_check = true;
                }
                else
                {
                    StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "박스 더미이다.", "묵직하지만,\n내용물은 대부분 잡동사니 뿐이다." }, "N"));
                }
                
            }
        }
    }

    private IEnumerator box_make()
    {
        yield return new WaitForSeconds(5.5f);
        Instantiate(box_prefab);
    }


    // Start is called before the first frame update
    void Start()
    {
        vent_checking = GameObject.FindObjectOfType<Vent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
