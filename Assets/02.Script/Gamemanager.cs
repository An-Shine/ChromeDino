using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] obstacles;
    public float spawnDelay; // �����ð�����

    private float spawnTimer; // �����ϱ����� Ÿ�̸�(�ð� ������ؼ�)
    public bool isSpawning; // �����ϱ� ���� ����
    private int spawnTracker; // � ��ֹ��� �������� ���ϱ� ���� ���� ( 0 ������1, 1 ������2, 2 ������3, 3 ������4, 4 �ͷ�
    void Start()
    {
        spawnTimer = spawnDelay;
    }

 
    void Update()
    {
        if(isSpawning.Equals(true))
        {
            spawnTimer -= Time.deltaTime; //������ �ð������
            if (spawnTimer <= 0)
            {
                spawnTimer = spawnDelay; // �ٽ� Ÿ�̸��� �ð��� �����Ǵ� �ð����� ����

                spawnTracker = Random.Range(0, obstacles.Length); //���������� �ͷ����� ���Ѵ�.

                if (spawnTracker == 0)
            {
                   // ������1
                    Instantiate(obstacles[spawnTracker], spawnPoints[0].position, spawnPoints[0].rotation);
                }
                else if (spawnTracker == 1)
                {
                    // ������2
                    Instantiate(obstacles[spawnTracker], spawnPoints[1].position, spawnPoints[1].rotation);
                }
                else if (spawnTracker == 2)
                {
                    // ������3
                    Instantiate(obstacles[spawnTracker], spawnPoints[1].position, spawnPoints[2].rotation);
                }
                else if (spawnTracker == 3)
                {
                   // ������4
                    Instantiate(obstacles[spawnTracker], spawnPoints[1].position, spawnPoints[3].rotation);
                }
                else if (spawnTracker == 4)//�ͷ�
                {
                    int randPoint = Random.Range(2, 5);
                    Instantiate(obstacles[spawnTracker], spawnPoints[randPoint].position, spawnPoints[randPoint].rotation);
                }
                else
                {
                    Instantiate(obstacles[spawnTracker], spawnPoints[1].position, spawnPoints[1].rotation);
                }
            }                     
            
            
        }
        
    }

}
