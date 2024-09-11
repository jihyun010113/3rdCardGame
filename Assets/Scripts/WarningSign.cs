using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSign : MonoBehaviour
{
    public GameObject warningSign;
    public Animator anim;
    public GameObject requestCardMach;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.Instance.isObstacle)
        {
            WarnigEffect();
        }
        else
        {
            WarningEnd();
        }
    }
    public void WarnigEffect() //∞Ê∞Ì√¢ «•Ω√
    {
        requestCardMach.SetActive(false);
        warningSign.SetActive(true);
        anim.SetBool("isWarning",true);
    }
    public void WarningEnd() //∞Ê∞Ì√¢ ≤®¡¸
    {
        requestCardMach.SetActive(true);
        warningSign.SetActive(false);
        anim.SetBool("isWarning", false);
    }
}
