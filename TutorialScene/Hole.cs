using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    public GameObject hole;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.name == "Hole")
            {
                //StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "환풍구를 타고 넘어갈까.." }, "N"));
                //Text_Effect.type(new string[] { "환풍구를 타고 넘어갈까.." }, "N");
                GameObject.FindObjectOfType<WOB_Alarm>().textbox.text = null;
                SceneManager.LoadScene("Bathroom1");
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
        hole.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
