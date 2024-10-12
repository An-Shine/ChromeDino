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
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, whatIsGround);

        //이제 스페이스바 누르면 점프 애니메이션 실행

        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded.Equals(true))
        {           
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);            
        }
        anim.SetBool("isGround", isGrounded);

    }
   
}
  /*Physics2D.OverLapCircle(groundCheckPoint, 반경, whatIsGround) > 지정된 원의 중심과 반경내에있는 2d콜라이더를 감지하는데사용 
   
   */
