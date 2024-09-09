using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_Manager : MonoBehaviour
{
    public float time;
    float time_Tmp;

    public RectTransform timeLimit;
    public GameObject lose;

    public GameObject timeCurtain;
    public Camera camera;

    private void Start()
    {
        time = 30f;
        time_Tmp = time;
    }

    private void Update()
    {
        if(time_Tmp > 0)
        {
            time_Tmp -= Time.deltaTime;
            TimeLimit();
        }
        else
        {
            time_Tmp = 0f;
            //게임 오버
            Time.timeScale = 0;
            lose.gameObject.SetActive(true);
        }
    }

    public void TimeLimit()
    {
        timeLimit.localScale = new Vector2(time_Tmp / time, timeLimit.localScale.y);
    }

    public void CameraRotation()
    {
        StartCoroutine("CameraRotation_Coroutine");
    }    

    IEnumerator CameraRotation_Coroutine()
    {
        for(int i=0; i<180; i++)
        {
            camera.gameObject.transform.rotation = Quaternion.Euler(0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }
        camera.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);

        yield return new WaitForSeconds(3f);
        camera.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void Wrong_Card()
    {
        time_Tmp -= 1f;
    }

    public void Correct_Card()
    {
        if (time_Tmp + 3f <= time)
            time_Tmp += 3f;
        else
            time_Tmp = time;
    }

    public void Curtain_Time()
    {
        timeCurtain.gameObject.SetActive(true);
        Invoke("Dis_timeCurtain", 5f);
    }

    void Dis_timeCurtain()
    {
        timeCurtain.gameObject.SetActive(false);
    }
}
