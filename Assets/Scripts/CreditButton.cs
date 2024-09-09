using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditButton : MonoBehaviour
{

    public GameObject CreditSence;

    public void Credit()
    {


        if (gameObject.activeSelf == true)
        {

            Debug.Log("if¹® ½ÇÇà");

            CreditSence.SetActive(true);


            






        }


        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {


            CreditSence.SetActive(false);



        }

        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {



            CreditSence.SetActive(false);




        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {



            CreditSence.SetActive(false);


        }

        else if (Input.GetKeyDown(KeyCode.Escape))
        {




            CreditSence.SetActive(false);


        }

    }
}
