using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditButton : MonoBehaviour
{

    public GameObject CreditSence;
    public GameObject OptionSence;

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


        if (OptionSence.activeSelf == false)
        {

            OptionSence.SetActive(true);


        }

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

