using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditButton : MonoBehaviour
{

    public GameObject CreditSence;




    private void Update()
    {

        if (Input.anyKeyDown) {



            if(CreditSence.activeSelf == true)
            {


                CreditSence.SetActive(false);
                Debug.Log("if¹® ½ÇÇàµÊ");

            }
        
        
        }


        







        

    }

    public void Credit()
    {


        if (CreditSence.activeSelf == false)
        {


            CreditSence.SetActive(true);





        }




    }


}

