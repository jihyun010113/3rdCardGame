using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float time;
    float time_Tmp;

    public RectTransform timeLimit;
    public GameObject win;
    public GameObject lose;

    public GameObject timeCurtain;
    public Camera camera;


    /*//card 매치 관련
    public Card firstCard;
    public Card secondCard;
    public int cardCount;*/

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        time = 30f;
        time_Tmp = time;
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
    }

    //카드 코드 작성 후 해방
    /*public void Mached()
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
    }*/

    public void Wrong_Card()
    {
        time_Tmp -= 1f;
    }

    public void Correct_Card()
    {
        if (time_Tmp + 3f <= time)
            time_Tmp += 3f;
        else
            time_Tmp = time;
    }

    //장애물 관련
    public void CameraRotation()
    {
        StartCoroutine("CameraRotation_Coroutine");
    }
    IEnumerator CameraRotation_Coroutine()
    {
        for (int i = 0; i < 180; i++)
        {
            camera.gameObject.transform.rotation = Quaternion.Euler(0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }
        camera.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);

        yield return new WaitForSeconds(3f);
        camera.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void Curtain_Time()
    {
        timeCurtain.gameObject.SetActive(true);
        Invoke("Dis_timeCurtain", 5f);
    }

    void Dis_timeCurtain()
    {
        timeCurtain.gameObject.SetActive(false);
    }
}
