using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Keycard_panel : MonoBehaviour, IPointerClickHandler
{
    public Effect_AudioClip_Manager EAM;
    public MeshRenderer mr;
    public Material mat;
    [SerializeField]
    KEY lockKey;

    public bool is_accessable;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.name == "GateAccessMachine")
            {
                if (lockKey!=null)
                {
                    if ((this.is_accessable != true) || (Inventory_Checking.InventoryChecking(lockKey.Key) != true))
                    {
                        //Debug.Log("클릭됨");
                        EAM.Effect_Sound("AccessDeny");
                        StartCoroutine(ColorChanger(Color.red));
                    }
                    else if ((this.is_accessable == true) && (Inventory_Checking.Item_Use(lockKey.Key) == true))
                    {
                        EAM.Effect_Sound("Access");
                        StartCoroutine(ColorChanger(Color.green));
                        SceneManager.LoadScene("WhiteRoom");

                    }
                }
                else if (lockKey == null)
                {
                    EAM.Effect_Sound("AccessDeny");
                    StartCoroutine(ColorChanger(Color.red));
                }
                
            }
                
        }
    }

    public IEnumerator ColorChanger(Color color)
    {
        mat.SetColor("_EmissionColor", color);
        yield return new WaitForSeconds(1f);
        mat.SetColor("_EmissionColor", Color.yellow);
    }


    // Start is called before the first frame update
    void Start()
    {
        EAM = GameObject.FindObjectOfType<Effect_AudioClip_Manager>();
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
