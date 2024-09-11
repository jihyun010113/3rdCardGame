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
        if (PlayerPrefs.HasKey("best"))
        {

            bestNow = PlayerPrefs.GetFloat("best");
            BestScoreNow_Txt.text = bestNow.ToString("N1");

        }

        else
        {

            BestScoreNow_Txt.text = "0.0f";
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
        SceneManager.LoadScene("StartScene");
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
        hardBtn.SetActive(false);
        int goalScore = 30;





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
