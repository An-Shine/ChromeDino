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
    public Transform groundCheckPoint; //빨간점의 위치
    public LayerMask whatIsGround; //Ground인지 비교할 LayerMask

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //처음에 Run 애니메이션 세팅(animator 에서 bool 타입의 파라미터 isGrounded를 설정했기 때문에 anim.SetBool 함수 이용
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
        // 땅과 충돌했는지 체크
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // 땅에 닿았을 때
        }
    }
   */
}
