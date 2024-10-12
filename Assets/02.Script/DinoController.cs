using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float jumpForce;
    public bool isGrounded;
    public bool isDown;
   
    private Animator anim;
    private Rigidbody2D rb;
    public Transform groundCheckPoint; //�������� ��ġ
    public LayerMask whatIsGround; //Ground���� ���� LayerMask

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //ó���� Run �ִϸ��̼� ����(animator ���� bool Ÿ���� �Ķ���� isGrounded�� �����߱� ������ anim.SetBool �Լ� �̿�
        anim.SetBool("isGround",true);
        
    }

    
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            anim.SetBool("isGround", false);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
       if(Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("isGround", true);
        }


    }
   /* void OnCollisionEnter2D(Collision2D collision)
    {
        // ���� �浹�ߴ��� üũ
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // ���� ����� ��
        }
    }
   */
}
