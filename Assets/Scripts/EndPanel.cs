using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{
    public Text Score;
    public Text BestScore;
    string key = "best";

    

    void OnEnable() //활성화 될때마다 호출되는 함수
    {
        
    }

    public void GameOver(float time)
    {
        
        Score.text = time.ToString("N2");
        if (PlayerPrefs.HasKey(key))
        {
            float Best = PlayerPrefs.GetFloat(key);
            if (Best < time)
            {
                PlayerPrefs.SetFloat(key, time);
                int cardScore = GameManager.Instance.cardCount;
                float timeScore = time *2;

                BestScore.text = $"{cardScore+timeScore}"; //보간문자열

            }
            else
            {
                BestScore.text = Best.ToString("N2");
            }
        }
        else 
        {
            PlayerPrefs.SetFloat (key, time);
            BestScore.text = time.ToString("N2");
        }
    }
}