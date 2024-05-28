using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float interval = 2.0f;
    float delta = 0;

    public static bool is_tracking = false;

    public GameObject character;

    public Monster_AudioClip_Manager MEAM;
    public Monster_Setting monster_setting;
    public Animator animator;
    private Transform target;
    private NavMeshAgent navAgent;

    public void Awake()
    {
        if (character == null)
        {
            character = GameObject.Find("head");
        }
        MEAM = GameObject.FindObjectOfType<Monster_AudioClip_Manager>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Character").transform;
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        monster_setting = GameObject.FindObjectOfType<Monster_Setting>();
        is_tracking = true;
        //StartCoroutine(move_sound());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            character.GetComponent<CharacterMovement>().moveSpeed = 10f;
            character.GetComponent<CharacterMovement>().jumpSpeed = 10f;
            is_tracking = false;
            // 사망 씬으로 전환
            SceneManager.LoadScene("GameOver");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (monster_setting.tracking_start == true)
        {
            //캐릭터 쫓아옴
            if (navAgent.destination != target.transform.position)
            {
                //MEAM.M_Effect_Sound("MWalk");
                animator.SetTrigger("Move");
                navAgent.SetDestination(target.transform.position);
            }
            else
            {
                animator.SetTrigger("Idle");
                navAgent.SetDestination(transform.position);
            }

            //울부짗음
            delta += Time.deltaTime;
            if (delta > interval)
            {
                delta = 0;

                int growl = Random.Range(0, 2);
                switch (growl)
                {
                    case 0:
                        MEAM.M_Effect_Sound("Growl1");
                        break;
                    case 1:
                        MEAM.M_Effect_Sound("Growl2");
                        break;
                }
                interval = Random.Range(5f, 15f);
            }
        }

    }

    public IEnumerator move_sound()
    {
        do
        {
            MEAM.M_Effect_Sound("MWalk");
            yield return new WaitForSeconds(0.5f);
        } while (true);
        
    }
   
}
