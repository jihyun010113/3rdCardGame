using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{


    public void ReMain()
    {


        SceneManager.LoadScene(0);
        AudioManager.Instance.ChangeBGM(0);


    }

    public void ReEasy()
    {


        SceneManager.LoadScene(3);
        AudioManager.Instance.ChangeBGM(3);


    }

    public void ReNormal()

    {

        SceneManager.LoadScene(2);
        AudioManager.Instance.ChangeBGM(2);



    }

    public void ReHard()

    {



        SceneManager.LoadScene(1);
        AudioManager.Instance.ChangeBGM(1);



    }


}
