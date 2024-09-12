using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public GameObject selectSence;
    bool isHard;
    float goalScore;
    public Button hardBtn;
    public Text BestScoreNow_Txt;
    float bestNow;
    public Animator btnAnim;
    


    public void Start()
      
    {
       //PlayerPrefs.DeleteAll(); // 베스트 스코어 초기화
        Time.timeScale = 1; // 타임스케일 초기화
        

        hardBtn.interactable = false;
        
        





        if (PlayerPrefs.HasKey("best"))
        {

           bestNow = PlayerPrefs.GetFloat("best");
           BestScoreNow_Txt.text = bestNow.ToString("N1");

        }

        else
        {

            BestScoreNow_Txt.text = "점수 없음";
        }



    }

    public void Update()
    {
        goalScore = 30.0f;
        isHard = goalScore <= bestNow;


        if ( isHard )
        {

            
            hardBtn.interactable = true;


        }



    }

    public void StageSelect()
    {


        if ( !selectSence.activeSelf )
        {

           
            selectSence.SetActive(true);



        }



    }

    public void Main()
    {


        SceneManager.LoadScene(0);
        AudioManager.Instance.ChangeBGM(0);

    }

    public void Easy()
    {


        SceneManager.LoadScene(3);
        AudioManager.Instance.ChangeBGM(3);

    }

    public void Normal()

    {

        SceneManager.LoadScene(2);
        AudioManager.Instance.ChangeBGM(2);


    }

    public void Hard()

    {

            SceneManager.LoadScene(1);
        AudioManager.Instance.ChangeBGM(1);

    }

    public void SelectBack()

    {

        if (selectSence.activeSelf == true)
        {


            selectSence.SetActive(false);



        }



    }




}
