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
    float goalScore = 30f;
    public Button hardBtn;
    public Text BestScoreNow_Txt;
    float bestNow;
    public Animator btnAnim;
    


    public void Start()
      
    {
        //PlayerPrefs.DeleteAll(); // ����Ʈ ���ھ� �ʱ�ȭ
        Time.timeScale = 1; // Ÿ�ӽ����� �ʱ�ȭ
        

        hardBtn.interactable = false;
    }


    public void StageSelect()
    {
        goalScore = 30f;

        if (PlayerPrefs.HasKey("best"))
        {
            bestNow = PlayerPrefs.GetFloat("best");
            BestScoreNow_Txt.text = bestNow.ToString("N1");
        }
        else
        {
            bestNow = 0;
            BestScoreNow_Txt.text = "���� ����";
        }

        if (bestNow >= goalScore)
            hardBtn.interactable = true;

        selectSence.SetActive(true);

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
