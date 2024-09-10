using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{
    public Text score;
    public Text Best;
    string key = "best";

    void OnEnable()
    {
        
    }

    void Awake()
    {

    }

    public void GameOver(float time)
    {
        
        score.text =time.ToString("N2");
        
        if (PlayerPrefs.HasKey(key))
        {
            float Best = PlayerPrefs.GetFloat(key);

            if (Best < time)
            {
                PlayerPrefs.SetFloat(key, time);
                // Best.text = time.ToString("N2");
            }
            else
            {
                PlayerPrefs.SetFloat(key, time);
                // Best.text = time.ToString("N2");
            }
        }
    }
}