using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public LevelManager levelManager;

    public float time;
    float time_Tmp;

    public RectTransform timeLimit;
    public GameObject win;
    public GameObject lose;

    public GameObject timeCurtain;
    public Camera camera;


    bool isHurry = false;

    AudioSource audioSource;
    public AudioClip clip;
    

    public Card firstCard;
    public Card secondCard;
    public int cardCount;
        


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
        time = 30f;
        time_Tmp = time;

        audioSource = GetComponent<AudioSource>();
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
        }

        if (isHurry == false && time_Tmp <= 10f ) // Time 10초미만일때 조급한 브금
        {
            isHurry = true; // 스위치가 켜짐

            
           
            AudioManager.Instance.audioSource.clip = AudioManager.Instance.HurryUpMusic;
            //AudioManager.Instance.audioSource.Stop();
            AudioManager.Instance.audioSource.Play();

            

        }
    }

 
    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            Correct_Card();
            audioSource.PlayOneShot(clip);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0)
            {
                win.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        else
        {
            Wrong_Card();
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }

    public void Wrong_Card()
    {
        time_Tmp -= 1f;
    }

    public void Correct_Card()
    {
        levelManager.Match_CntUp();
        if (time_Tmp + 3f <= time)
            time_Tmp += 3f;
        else
            time_Tmp = time;
    }
}
