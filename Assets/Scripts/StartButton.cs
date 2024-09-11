using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public GameObject selectSence;
    public EndPanel endPanel; // ���������� �Ҵ�
    bool isHard;
    int goalScore;
    public GameObject hardBtn;
    public Text bestNowTxt;
    float bestNow;


    public void Start()
    {
        bestNow = endPanel.GetBestScore();
        bestNowTxt.text = bestNow.ToString("N1");

    }

    public void StageSelect()
    {


        if ( selectSence.activeSelf == false)
        {


            selectSence.SetActive(true);



        }



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
       
        bool unLock = GetComponent<Button>().enabled = false;
        float bestScore = endPanel.GetBestScore();





        int goalScore = 30; // �ϵ� ��带 ������ �����ؾ� �ϴ� ����



        isHard = goalScore <= bestScore;



        if (isHard)
        {
            hardBtn.SetActive(true);
            unLock = true;
            SceneManager.LoadScene("HardScene");
            
        
        
        
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
