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
    private Vector2 saveOffset;
    private Vector2 savedSize;
    //Boxcollider2D를 참조할 변수
    private BoxCollider2D boxCollider;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        SaveColliderSetting();
        //처음에 Run 애니메이션 세팅(animator 에서 bool 타입의 파라미터 isGrounded를 설정했기 때문에 anim.SetBool 함수 이용
        anim.SetBool("isGround",true);
        anim.SetBool("isDown", false);
    }

    
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, whatIsGround);

        //이제 스페이스바 누르면 점프 애니메이션 실행

        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded.Equals(true))
        {           
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);            
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow)&& isGrounded.Equals(true))
        {
            SetDownArrowKeyDown();
        }
        if(Input.GetKeyUp(KeyCode.DownArrow)&& isGrounded.Equals(true))
        {
            SetDownArrowKeyUp();
        }
        anim.SetBool("isGround", isGrounded);
    }
    void SaveColliderSetting()
    {
        saveOffset = boxCollider.offset;
        savedSize = boxCollider.size;
    }
    void LoadColliderSettings()
    {
        boxCollider.offset = saveOffset;
        boxCollider.size = savedSize;
    }

    void SetDownArrowKeyDown()
    {
        anim.SetBool("isDown", true);
        boxCollider.offset = new Vector2(0f, -0.25f);
        boxCollider.size = new Vector2(1.39f, 0.76f);

    }

    void SetDownArrowKeyUp()
    {
        anim.SetBool("isDown", false);
        LoadColliderSettings();

    }


    private void OnDrawGizmos() //범위를 그리는 함수
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, 0.2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            Debug.Log("게임 오버");
        }

        else if (collision.CompareTag("Point"))
        {
            Debug.Log("점수 획득");
        }
    }

}
  /*Physics2D.OverLapCircle(groundCheckPoint, 반경, whatIsGround) > 지정된 원의 중심과 반경내에있는 2d콜라이더를 감지하는데사용 
   
   */
