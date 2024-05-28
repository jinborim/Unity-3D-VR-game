using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GoOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {

            //Debug.Log("충돌");
            StartCoroutine(Ending());
        }
    }

    public IEnumerator Ending()
    {
        StartCoroutine(Faded.Desolving());
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("EpScene");
    }
}
