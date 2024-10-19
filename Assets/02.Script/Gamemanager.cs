using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] obstacles;
    public float spawnDelay; // 스폰시간간격

    private float spawnTimer; // 스폰하기위한 타이머(시간 재기위해서)
    public bool isSpawning; // 스폰하기 위한 변수
    private int spawnTracker; // 어떤 장애물을 스폰할지 픽하기 위한 변수 ( 0 선인장1, 1 선인장2, 2 선인장3, 3 선인장4, 4 익룡
    void Start()
    {
        spawnTimer = spawnDelay;
    }

 
    void Update()
    {
        if(isSpawning.Equals(true))
        {
            spawnTimer -= Time.deltaTime; //딜레이 시간을잰다
            if (spawnTimer <= 0)
            {
                spawnTimer = spawnDelay; // 다시 타이머의 시간을 스폰되는 시간으로 리셋

                spawnTracker = Random.Range(0, obstacles.Length); //선인장일지 익룡일지 정한다.

                if (spawnTracker == 0)
            {
                   // 선인장1
                    Instantiate(obstacles[spawnTracker], spawnPoints[0].position, spawnPoints[0].rotation);
                }
                else if (spawnTracker == 1)
                {
                    // 선인장2
                    Instantiate(obstacles[spawnTracker], spawnPoints[1].position, spawnPoints[1].rotation);
                }
                else if (spawnTracker == 2)
                {
                    // 선인장3
                    Instantiate(obstacles[spawnTracker], spawnPoints[1].position, spawnPoints[2].rotation);
                }
                else if (spawnTracker == 3)
                {
                   // 선인장4
                    Instantiate(obstacles[spawnTracker], spawnPoints[1].position, spawnPoints[3].rotation);
                }
                else if (spawnTracker == 4)//익룡
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
