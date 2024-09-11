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
    int goalScore;
    public GameObject hardBtn;
    public Text BestScoreNow_Txt;
    float bestNow;
    


    public void Start()
      
    {
        hardBtn.SetActive(false);

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

    public void StageSelect()
    {


        if ( !selectSence.activeSelf )
        {

            //PlayerPrefs.DeleteAll(); // 베스트 스코어 초기화
            selectSence.SetActive(true);



        }



    }

    public void Main()
    {


        SceneManager.LoadScene("MainScene");


    }

    public void Easy()
    {


        SceneManager.LoadScene("EazyScene");


    }

    public void Normal()

    {

        SceneManager.LoadScene("NormalScene");



    }

    public void Hard()

    {
        
        float goalScore = 30;





        isHard = goalScore <= bestNow;



        if (isHard)
        {
            hardBtn.SetActive(true);
            SceneManager.LoadScene("HardScene");




        }

        else 
        
        
        {

            Debug.Log("하드모드를 열 수 없음");
                
                
                }


    }

    public void SelectBack()

    {

        if (selectSence.activeSelf == true)
        {


            selectSence.SetActive(false);



        }



    }




}
