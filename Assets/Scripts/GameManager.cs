using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float time;
    public float time_Tmp;
    public Text time_Txt;


    public RectTransform timeLimit;
    public GameObject card;
    public GameObject win;
    public GameObject lose;
    public GameObject RequesteBack;
    public GameObject warningSign;
    public Animator warningSignAnim;

    /*public GameObject timeCurtain;
    public Camera camera;*/


    bool isHurry = false;
    bool isOver = false;
    AudioSource audioSource;
    public AudioClip clip;


    public Card firstCard;
    public Card secondCard;
    public int cardCount;

    int sceneIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(sceneIndex);

        if(sceneIndex == 3)
        {
            time = 35f;
        }
        else if (sceneIndex == 2)
        {
            time = 30f;
        }
        else if (sceneIndex == 1)
        {
            time = 25f;
        }
        time_Tmp = time;

        audioSource = GetComponent<AudioSource>();
        RequesteBack.SetActive(true);//카드를 맞춰주세요 켜기(기본)   

    }

    // Update is called once per frame
    void Update()
    {           
        if (time_Tmp > 0)
        {
            time_Tmp -= Time.deltaTime;
            timeLimit.localScale = new Vector2(time_Tmp / time, timeLimit.localScale.y);
        }
        else
        {
            time_Tmp = 0f;
            //게임 오버
            Time.timeScale = 0;
            lose.gameObject.SetActive(true);
            RequesteBack.SetActive(false); //카드를 맞춰주세요 끄기

            if (isOver== false && time_Tmp <= 0.0f)
            {
                isOver = true;
                Debug.Log("isover");
                AudioManager.Instance.audioSource.clip = AudioManager.Instance.BackGorundMusic;
                AudioManager.Instance.audioSource.Stop();
                AudioManager.Instance.audioSource.Play();




            }
        }
        time_Txt.text = time_Tmp.ToString("N1");

        if (isHurry == false && time_Tmp <= 10f) // Time 10초미만일때 조급한 브금
        {
            isHurry = true; // 스위치가 켜짐            

            AudioManager.Instance.audioSource.clip = AudioManager.Instance.HurryUpMusic;
            AudioManager.Instance.audioSource.Stop();
            AudioManager.Instance.audioSource.Play();


        }



    }
    public void ObstacleSign() //장애물 실행시 사인표출
    {
        //Invoke("ObstacleSignOnOff", 4f);
        warningSign.SetActive(true);        
        warningSignAnim.SetBool("isWarning", true);
        RequesteBack.SetActive(false);
    }
    public void ObstacleSignOnOff() //장애물 실행시 사인표출
    {        
        warningSign.SetActive(false);
        warningSignAnim.SetBool("isWarning", false);
        RequesteBack.SetActive(true);
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            Correct_Card();
            audioSource.PlayOneShot(clip);
            Invoke("InvokeCardDestroy", 0.5f);

            cardCount -= 2;
            if (cardCount == 0)
            {
                win.gameObject.SetActive(true);
                RequesteBack.gameObject.SetActive(false);//카드를 맞춰주세요 끄기

                Time.timeScale = 0f;
            }
        }
        else
        {
            Wrong_Card();
            Invoke("InvokeCardClose",0.5f);
        }
        
    }
    public void InvokeCardDestroy()  //카드 삭제후, null값으로 변경
    {
        firstCard.DestroyCard();
        secondCard.DestroyCard();         
        firstCard = null;
        secondCard = null;        

    }
    public void InvokeCardClose() //카드 다시 뒤집기 후, null값으로 변경
    {
        firstCard.CloseCard();
        secondCard.CloseCard();
        firstCard = null;
        secondCard = null;
    }


    public void Wrong_Card()
    {
        if (sceneIndex == 3)
        {
            time_Tmp -= 1f;
        }
        else if (sceneIndex == 2)
        {
            time_Tmp -= 1.5f;
        }
        else if (sceneIndex == 1)
        {
            time_Tmp -= 2f;
        }
    }

    public void Correct_Card()
    {
        if(sceneIndex != 3)
            LevelManager.Instance.Match_CntUp();
        if (time_Tmp + 3f <= time)
            time_Tmp += 3f;
        else
            time_Tmp = time;
    }
}
