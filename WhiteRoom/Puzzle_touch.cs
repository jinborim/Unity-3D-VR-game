using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle_touch : MonoBehaviour
{
    //public PuzzlePiece pp;

    public GameObject Puzzle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Movement_Controll.Move_Stop();
        //SceneManager.LoadScene("PuzzleScene");
        SceneManager.LoadScene("PuzzleScene", LoadSceneMode.Additive);
        Debug.Log("퍼즐 scene으로 이동");

    }

    

        
  
}
