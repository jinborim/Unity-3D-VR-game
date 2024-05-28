using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Setting : MonoBehaviour
{
    public GameObject character;
    [SerializeField]
    GameObject Monster;
    [SerializeField]
    AudioSource bgm;
    public Monster_AudioClip_Manager MEAM;
    public string[] Character_Line = new string[] {"화장실에서 겨우 나왔다...", "건물은 다 무너진거같고...", "여긴 어디지?\n연구동?", "...?", "어디선가 이상한 소리가..." };

    public bool tracking_start=false;

    // Start is called before the first frame update
    void Start()
    {
        Monster.gameObject.SetActive(false);
        MEAM = GameObject.FindObjectOfType<Monster_AudioClip_Manager>();
        if (character == null)
        {
            character = GameObject.Find("head");
        }
        StartCoroutine(Scene_Play());
    }

    public IEnumerator move_sound()
    {
        do
        {
            MEAM.M_Effect_Sound("MWalk");
            yield return new WaitForSeconds(0.5f);
        } while (true);

    }

    private IEnumerator Scene_Play()
    {
        StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, Character_Line, "N"));
        yield return new WaitForSeconds(10f);
        MEAM.M_Line_Sound("Growl");
        yield return new WaitForSeconds(0.5f);
        Monster.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.3f);
        StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "나를 감히 이렇게 만들어 놔?" }, "N"));
        MEAM.M_Line_Sound("Line1");
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "너도 똑같이 만들어주마!" }, "N"));
        MEAM.M_Line_Sound("Line2");
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "너희 때문에 내 삶이 망가졌어..." }, "N"));
        MEAM.M_Line_Sound("Line3");
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "여기서 절대 나갈 수 없으니 꿈 깨!" }, "N"));
        MEAM.M_Line_Sound("Line4");
        yield return new WaitForSeconds(3f);

        StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] {"큰일이다...", "일단 안에서 얻은 카드키가 있으니,\n이 문들 중 하나가 열리길 기도하는 수 밖에." }, "N"));
        yield return new WaitForSeconds(5f);
        StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().Item_Use_Text, new string[] { "키패드에 카드를 대봐야한다!" }, "N"));
        character.GetComponent<CharacterMovement>().moveSpeed = 50f;
        character.GetComponent<CharacterMovement>().jumpSpeed = 20f;
        bgm.Play();
        tracking_start = true;
        StartCoroutine(move_sound());


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
