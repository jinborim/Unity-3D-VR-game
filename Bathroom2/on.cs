using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class on : MonoBehaviour
{
    //맵 이동할 변수 선언

    public string transferMapName;



    //콜라이더에 닿으면 실행하라

    private void OnTriggerEnter(Collider collision)
    {

  //플레이어라는 이름을 가진 게임 오브젝트가 콜라이더에 닿으면.. 

        if(collision.gameObject.name == "head")

        {

            //씬 이동 시켜라.

            SceneManager.LoadScene(transferMapName);

        }

    }
}
