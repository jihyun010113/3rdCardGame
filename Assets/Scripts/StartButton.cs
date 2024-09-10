using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject selectSence;

    public void StageSelect()
    {


        if ( selectSence.activeSelf == false)
        {


            selectSence.SetActive(true);



        }



    }

    public void SelectBack()
    {


        if( selectSence.activeSelf == true)
        { selectSence.SetActive(false);}



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

}
