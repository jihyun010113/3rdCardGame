using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditButton : MonoBehaviour
{
    public GameObject CreditSence;
    public GameObject OptionSence;

    public GameObject sliderParent;

    /*private void Update()
    {

        if (Input.anyKeyDown) {



            if(CreditSence.activeSelf == true)
            {


                CreditSence.SetActive(false);
                Debug.Log("if¹® ½ÇÇàµÊ");

            }




        }

        if (Input.GetKeyDown(KeyCode.Escape)  )
        {


            OptionSence.SetActive(false);


        }




    }*/

    public void Option()
    {
        AudioManager.Instance.audioSlider = sliderParent.GetComponentInChildren<Slider>();

        if (OptionSence.activeSelf == false)
        {
            AudioManager.Instance.audioSlider.value = AudioManager.Instance.sound;
            OptionSence.SetActive(true);
        }

    }

    public void AudioControl()
    {
        AudioManager.Instance.sound = AudioManager.Instance.audioSlider.value;

        if (AudioManager.Instance.sound == -40f) AudioManager.Instance.masterMixer.SetFloat("Master", -80);
        else AudioManager.Instance.masterMixer.SetFloat("Master", AudioManager.Instance.sound);
    }

    public void OptionBack()
    {

        OptionSence.SetActive(false);


    }

    public void Credit()
    {


        if (CreditSence.activeSelf == false)
        {


            CreditSence.SetActive(true);

        }


    }

    public void CreditBack()
    {



        if (CreditSence.activeSelf == true)
        {


            CreditSence.SetActive(false);



        }

    }

}

