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
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, whatIsGround);

        //���� �����̽��� ������ ���� �ִϸ��̼� ����

        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded.Equals(true))
        {           
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);            
        }
        anim.SetBool("isGround", isGrounded);

    }
   
}
  /*Physics2D.OverLapCircle(groundCheckPoint, �ݰ�, whatIsGround) > ������ ���� �߽ɰ� �ݰ泻���ִ� 2d�ݶ��̴��� �����ϴµ���� 
   
   */
