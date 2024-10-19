using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float moveSpeedX;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

 
    void Update()
    {
        rb.velocity = new Vector2(moveSpeedX, 0f);

    }

    private void OnBecameInvisible() // 카메라밖으로나가면 보이게해주는 함수
    {
        Destroy(gameObject);
    }
}


