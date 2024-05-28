using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform cameraTransform;
    public CharacterController CharacterController;

    [SerializeField]
    AudioClip walkSound;

    public bool is_Moving=false;

    public float moveSpeed = 10f;
    public float jumpSpeed = 10f;
    public float gravity = -20f;
    public float yVelocity = 0;

    public static bool is_movable=true;

    public Effect_AudioClip_Manager EAM;
    public EffectSound_Manager WEAM;

    public string walkingM;

    //public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        is_movable = true;
        cameraTransform = Camera.main.transform;
        //crossHair = Instantiate(crossHair);
        EAM = GameObject.FindObjectOfType<Effect_AudioClip_Manager>();
        WEAM = GameObject.FindObjectOfType<EffectSound_Manager>();

    }

    

    // Update is called once per frame
    void Update()
    {
        if (is_movable == true)
        {
            float h = Input.GetAxis("Horizontal");

            float v = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(h, 0, v);
            moveDirection = cameraTransform.TransformDirection(moveDirection);

            moveDirection *= moveSpeed;


            if (CharacterController.isGrounded)
            {
                yVelocity = 0;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    yVelocity = jumpSpeed;
                }
            }
            yVelocity += (gravity * Time.deltaTime);
            moveDirection.y = yVelocity;
            CharacterController.Move(moveDirection * Time.deltaTime);

            if ((moveDirection.x != 0) || (moveDirection.z != 0))
            {
                is_Moving = true;
            }
            else
            {
                is_Moving = false;
            }

            if (is_Moving)
            {
                if (!WEAM.Effect_source.isPlaying)
                {
                    if (EnemyMovement.is_tracking == true) //일단은 임시로 EnemyMovement에 변수 할당..
                    {
                        WEAM.Effect_source.pitch = 1.4f;
                    }
                    else
                    {
                        WEAM.Effect_source.pitch = 1f;
                    }
                    WEAM.Play_WalkSound("Walk");
                }

            }
            else
            {
                WEAM.Effect_source.Stop();
            }
        }
        


    }
    


    
}
