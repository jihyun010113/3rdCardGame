using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public void ReMain()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void ReEasy()
    {
        SceneManager.LoadScene("EazyScene");
    }
    public void ReNormal()
    {
        SceneManager.LoadScene("NormalScene");
    }
    public void ReHard()
    {
        SceneManager.LoadScene("HardScene");
    }
}
