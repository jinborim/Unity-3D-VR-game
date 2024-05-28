using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EpText : MonoBehaviour, IPointerClickHandler
{


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.name == "Cube")
            {
                //&& hit.collider.CompareTag("TextPanel")  

                //Debug.Log("터치됨");
                    StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<TextAlarm>().textR, new string[] { 
                        "그렇게 나는 탈출했다.", "정신 없이 탈출한 나는 그대로 경찰에 신고했고, 구조됐다.", "그 후 그 끔찍한 사건을 다시 접하게 된 것은 뉴스 기사였다.",
                        "WYH 연구소의 붕괴가 사회에 큰 파문을 일었다.", "말 그대로 연구소의 건물이 붕괴한 것이다.", 
                        "여기서 더욱 사람들을 경악케 한 것은 해당 연구소에서 허위 임상 실험과 인신 매매 등의 방식으로 피실험자에게 불법 시술과 같은 비윤리적인 인체 실험을 강행한 것으로 밝혀졌다.",
                        "WYH 연구소는 유명 기업의 산하 시설로 해당 기업은 연구소 독자적으로 벌인 일이라며 부인하고 있다고 한다.", "...", "..", ".", "END"}, "N"));

                    
            } 
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}
