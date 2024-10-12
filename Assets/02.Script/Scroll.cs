using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float mapSpeed; // x축 스크롤속도
    private float mapOffset;
    private Renderer quadRenderer;
    public bool isCloud; // 구름 인지 아닌지 판단하기위한 bool타입
    public float cloudScrollSpeedX = 0.5f; //구름이 움직이는 속도
    void Start()
    {
        quadRenderer = GetComponent<Renderer>(); //quad 의 Renderer 를 가져옴
    }

    
    void Update()
    {
        if(isCloud.Equals(true))
        {
           transform.Translate(Vector2.left*cloudScrollSpeedX*Time.deltaTime);
           // this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - cloudScrollSpeedX * Time.deltaTime, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            if (transform.position.x < -11.0f)
            {
                
                transform.position = new Vector2(11f, Random.Range(1f, 4f));
            }
            
        }
        else
        {
            mapOffset += Time.deltaTime * mapSpeed; // 시간에따라 uv 오프셋 값을 계산
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(mapOffset, 0f); // Material의 메인 텍스쳐의 오프셋조정
        }

       
    }
}
