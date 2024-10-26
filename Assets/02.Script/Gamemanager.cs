using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // ui랑 TextMeshPro 사용할때 무조건 들어가야함.
using TMPro;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance; //싱글톤 인스턴스를 저장할 정적변수

    public Transform[] spawnPoints;
    public GameObject[] obstacles;
    public float spawnDelay; // 스폰시간간격

    private float spawnTimer; // 스폰하기위한 타이머(시간 재기위해서)
    public bool isSpawning; // 스폰하기 위한 변수
    private int spawnTracker; // 어떤 장애물을 스폰할지 픽하기 위한 변수 ( 0 선인장1, 1 선인장2, 2 선인장3, 3 선인장4, 4 익룡

    public int mainScore; //실제로 게임 도중 1씩 더해질 int형 변수
    public TextMeshProUGUI mainScore_Text; //게임화면 우측상단에 ScoreText 오브젝트의 text 변수

    public GameObject gameOver_Panell; // 게임오버패널 - 게임오버시 창을 활성화해주기 위한 변수
    public TextMeshProUGUI bestScore_Text; // 나의 역대 최고점수
    public TextMeshProUGUI endScore_Text; // 이번판 현재점수
    
    private void Awake()
    {
        if (instance != null && instance != this) // 인스턴스가 존재하면, 그리고 그 인스턴스가 현재 이 오브젝트가 아니면
        {
            Destroy(this.gameObject); // 삭제
        }
        else
        {
            instance = this; // 인스턴스가 존재하지 않으면 현재 오브젝트를 인스턴스로 설정하고 유지한다.
        }
    }  // 이대로 싱글톤 쓸때 복붙해도 가능함
    




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
    public void Score_UI_Update()
    {
        mainScore++;
        mainScore_Text.text = "점수: " + mainScore.ToString();
    }
    public void Gameover()
    {
        GetComponent<AudioSource>().Play();
        Time.timeScale = 0f; //게임의 시간을 멈춤
        if(mainScore > PlayerPrefs.GetInt("최고점수", 0)) // 현재 점수가 저장되어있던 베스트점수(없다면 기본0)보다 높다면
        {
            PlayerPrefs.SetInt("최고점수", mainScore); // 마지막점수는 MainScore점수를 문자화해서 넣어줌
        }

        bestScore_Text.text = "최고점수 : " + PlayerPrefs.GetInt("최고점수").ToString(); //베스트점수는 저장되어있던 베스트점수를 문자로 불러옴
        endScore_Text.text = "최종점수 : " + mainScore.ToString(); // 마지막점수는 MainScore 점수를 문자화 해서 넣어줌
      gameOver_Panell.SetActive(true);


    }

    public void RestartGame()
    {
        Time.timeScale = 1f; //게임 시간을 다시 흐르게함
        SceneManager.LoadScene("GameScene");
        
    }
}
