using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Controller : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    //public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;    //地面についているか

    //スライディング
    private bool isSliding = false;
    public float slideSpeed = 10f;
    public float slideTime = 1f;

    private float slideTimer = 0f;



    // Start is called before the first frame update
    void Start()
    {

        // CharacterController コンポーネントのステップ高さを設定
        controller.stepOffset = 0.5f; // 適切な値を設定してください
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // 地面についているとき、y方向の速度をリセット
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10f;
        }
        else
        {
            speed = 5f;
        }

       

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // ジャンプ処理
        }

        // スライディングの処理
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            StartSlide();
        }

        //重力
        velocity.y += gravity * Time.deltaTime;

        //移動処理
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }

    void StartSlide()
    {
        if (!isSliding)
        {
            isSliding = true;
            slideTimer = 0f;
        }
    }

    void Slide()
    {
        slideTimer += Time.deltaTime;

        if (slideTimer < slideTime)
        {
            // スライディング中はスライディング速度で移動
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 slideMove = transform.right * x + transform.forward * z;
            controller.Move(slideMove * slideSpeed * Time.deltaTime);
        }
        else
        {
            // スライディング時間が経過したらスライディング終了
            isSliding = false;
        }
    }
}
