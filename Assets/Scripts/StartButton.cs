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


}
