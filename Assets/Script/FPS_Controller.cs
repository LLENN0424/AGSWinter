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
    bool isGrounded;

    //�X���C�f�B���O
    private bool isSliding = false;
    public float slideSpeed = 10f;
    public float slideTime = 1f;

    private float slideTimer = 0f;



    // Start is called before the first frame update
    void Start()
    {

        // CharacterController �R���|�[�l���g�̃X�e�b�v������ݒ�
        controller.stepOffset = 0.5f; // �K�؂Ȓl��ݒ肵�Ă�������
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // �n�ʂɂ��Ă���Ƃ��Ay�����̑��x�����Z�b�g
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
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // �W�����v����
        }

        // �X���C�f�B���O�̏���
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            StartSlide();
        }

        //�d��
        velocity.y += gravity * Time.deltaTime;

        //�ړ�����
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
            // �X���C�f�B���O���̓X���C�f�B���O���x�ňړ�
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 slideMove = transform.right * x + transform.forward * z;
            controller.Move(slideMove * slideSpeed * Time.deltaTime);
        }
        else
        {
            // �X���C�f�B���O���Ԃ��o�߂�����X���C�f�B���O�I��
            isSliding = false;
        }
    }
}
