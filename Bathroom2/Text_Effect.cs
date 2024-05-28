using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Effect : MonoBehaviour
{

    static public bool is_text=false;

    static public IEnumerator Typing(Text text_base,string[] dialogue, string Plus)
    {
        //이 함수가 시작할 때 한 번 내용물을 싹 비워준다(안그러면 전의 대사에 추가해서 나옴)
        //위의 Typing_trigger에서 dialogue를 가져와서 talk라는 지역변수?로 사용

        if (is_text == false)
        {
            is_text = true;
            text_base.text = null;
            text_base.gameObject.SetActive(true);

            for (int i = 0; i < dialogue.Length; i++)
            {
                text_base.text = null;
                string talk = dialogue[i];
                for (int j = 0; j < talk.Length; j++)
                {
                    //입력받은 대사의 길이만큼 반복
                    //위에서 Text형식으로 지정해준 dialog_context의 텍스트에 String 형식인 talk를 한글자씩 집어넣어줌
                    // >> 결과적으로 텍스트에 한글자씩 추가되는 것이므로 화면상으론 한글자씩 말하는거처럼 보이게 됨
                    text_base.text += talk[j];
                    yield return new WaitForSeconds(0.05f); //코러틴 함수에서 사용하는 함수로, 지정된 시간에 한번씩 돌아가게 됨 > 글자 출력 속도랑 같다고 볼 수 있음
                }
                yield return new WaitForSeconds(0.5f);
            }
            Plus_effect(Plus);
            text_base.transform.gameObject.SetActive(false);
            is_text = false;
        }
        
    }

    public static void Plus_effect(string Plus)
    {
        switch (Plus)
        {
            case "N":
                return;
            case "D":
                StaticCoroutine.Start(Faded.Desolving());
                return;
            case "C":
                return;
        }
    }

    static public void type(string[] dialogue, string Plus)
    {
        // 코루틴이 정지될 때를 대비해서 만듦
        StaticCoroutine.Start(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, dialogue, Plus));
    }

    

}
