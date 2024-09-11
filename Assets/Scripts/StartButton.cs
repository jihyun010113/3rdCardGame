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

        hardBtn.interactable = false;
        GetComponent<Animator>();
        





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

            //PlayerPrefs.DeleteAll(); // 베스트 스코어 초기화
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

            SceneManager.LoadScene("HardScene");


    }

    public void SelectBack()

    {

        if (selectSence.activeSelf == true)
        {


            selectSence.SetActive(false);



        }



    }




}
