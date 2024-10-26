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
    private Vector2 saveOffset;
    private Vector2 savedSize;
    //Boxcollider2D�� ������ ����
    private BoxCollider2D boxCollider;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        SaveColliderSetting();
        //ó���� Run �ִϸ��̼� ����(animator ���� bool Ÿ���� �Ķ���� isGrounded�� �����߱� ������ anim.SetBool �Լ� �̿�
        anim.SetBool("isGround",true);
        anim.SetBool("isDown", false);
    }

    
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, whatIsGround);

        //���� �����̽��� ������ ���� �ִϸ��̼� ����

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


    private void OnDrawGizmos() //������ �׸��� �Լ�
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, 0.2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            Debug.Log("���� ����");
        }

        else if (collision.CompareTag("Point"))
        {
            Debug.Log("���� ȹ��");
        }
    }

}
  /*Physics2D.OverLapCircle(groundCheckPoint, �ݰ�, whatIsGround) > ������ ���� �߽ɰ� �ݰ泻���ִ� 2d�ݶ��̴��� �����ϴµ���� 
   
   */
