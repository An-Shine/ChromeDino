using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float mapSpeed; // x�� ��ũ�Ѽӵ�
    private float mapOffset;
    private Renderer quadRenderer;
    public bool isCloud; // ���� ���� �ƴ��� �Ǵ��ϱ����� boolŸ��
    public float cloudScrollSpeedX = 0.5f; //������ �����̴� �ӵ�
    void Start()
    {
        quadRenderer = GetComponent<Renderer>(); //quad �� Renderer �� ������
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
            mapOffset += Time.deltaTime * mapSpeed; // �ð������� uv ������ ���� ���
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(mapOffset, 0f); // Material�� ���� �ؽ����� ����������
        }

       
    }
}
