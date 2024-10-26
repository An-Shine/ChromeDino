using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // ui�� TextMeshPro ����Ҷ� ������ ������.
using TMPro;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance; //�̱��� �ν��Ͻ��� ������ ��������

    public Transform[] spawnPoints;
    public GameObject[] obstacles;
    public float spawnDelay; // �����ð�����

    private float spawnTimer; // �����ϱ����� Ÿ�̸�(�ð� ������ؼ�)
    public bool isSpawning; // �����ϱ� ���� ����
    private int spawnTracker; // � ��ֹ��� �������� ���ϱ� ���� ���� ( 0 ������1, 1 ������2, 2 ������3, 3 ������4, 4 �ͷ�

    public int mainScore; //������ ���� ���� 1�� ������ int�� ����
    public TextMeshProUGUI mainScore_Text; //����ȭ�� ������ܿ� ScoreText ������Ʈ�� text ����

    public GameObject gameOver_Panell; // ���ӿ����г� - ���ӿ����� â�� Ȱ��ȭ���ֱ� ���� ����
    public TextMeshProUGUI bestScore_Text; // ���� ���� �ְ�����
    public TextMeshProUGUI endScore_Text; // �̹��� ��������
    
    private void Awake()
    {
        if (instance != null && instance != this) // �ν��Ͻ��� �����ϸ�, �׸��� �� �ν��Ͻ��� ���� �� ������Ʈ�� �ƴϸ�
        {
            Destroy(this.gameObject); // ����
        }
        else
        {
            instance = this; // �ν��Ͻ��� �������� ������ ���� ������Ʈ�� �ν��Ͻ��� �����ϰ� �����Ѵ�.
        }
    }  // �̴�� �̱��� ���� �����ص� ������
    




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
    public void Score_UI_Update()
    {
        mainScore++;
        mainScore_Text.text = "����: " + mainScore.ToString();
    }
    public void Gameover()
    {
        GetComponent<AudioSource>().Play();
        Time.timeScale = 0f; //������ �ð��� ����
        if(mainScore > PlayerPrefs.GetInt("�ְ�����", 0)) // ���� ������ ����Ǿ��ִ� ����Ʈ����(���ٸ� �⺻0)���� ���ٸ�
        {
            PlayerPrefs.SetInt("�ְ�����", mainScore); // ������������ MainScore������ ����ȭ�ؼ� �־���
        }

        bestScore_Text.text = "�ְ����� : " + PlayerPrefs.GetInt("�ְ�����").ToString(); //����Ʈ������ ����Ǿ��ִ� ����Ʈ������ ���ڷ� �ҷ���
        endScore_Text.text = "�������� : " + mainScore.ToString(); // ������������ MainScore ������ ����ȭ �ؼ� �־���
      gameOver_Panell.SetActive(true);


    }

    public void RestartGame()
    {
        Time.timeScale = 1f; //���� �ð��� �ٽ� �帣����
        SceneManager.LoadScene("GameScene");
        
    }
}
