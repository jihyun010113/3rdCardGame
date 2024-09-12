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
    int cardScore;
    float totalScore;
    float timeScore;
    public float Best;

    void OnEnable() //활성화 될때마다 호출되는 함수
    {
        GameOver(GameManager.Instance.time_Tmp);
        AudioManager.Instance.audioSource.clip = AudioManager.Instance.EndPanelSound;
        AudioManager.Instance.audioSource.Stop();
        AudioManager.Instance.audioSource.Play();
        
    }

    public void GameOver(float time)
    {
        cardScore = 16 - GameManager.Instance.cardCount;
        timeScore = time * 2;
        totalScore = cardScore + timeScore;
        if (PlayerPrefs.HasKey(key))
        {
            Best = PlayerPrefs.GetFloat(key);
            if (Best < totalScore)
            {
                PlayerPrefs.SetFloat(key, totalScore);

                BestScore.text = $"{cardScore + timeScore}"; //보간문자열
                //ctrl k+d 꿀팁
            }
            else
            {
                BestScore.text = Best.ToString("N1");
            }
        }
        else
        {
            PlayerPrefs.SetFloat(key, totalScore);
            BestScore.text = totalScore.ToString("N1");
        }
        Score.text = totalScore.ToString("N1");
    }




}