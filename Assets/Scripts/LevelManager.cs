using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public int match_cnt;

    public int[] obstacle_arr = { 0, 1 };
    public GameObject timeCurtain;
    public Camera camera;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        match_cnt = 0;
    }

    public void Match_CntUp()
    {
        //asdf
        match_cnt++;
        if (match_cnt >= 2)
        {
            if(obstacle_arr[0] != 100 || obstacle_arr[1] != 100)
            {
                match_cnt = 0;
                Obstacle();
            }
        }
    }

    public void Obstacle()
    {
        int ran_Obstacle;
        do
        {
            ran_Obstacle = Random.Range(0, 2);
        } while (obstacle_arr[ran_Obstacle] == 100);

        obstacle_arr[ran_Obstacle] = 100;

        if (ran_Obstacle == 0)
            CameraRotation();
        else if (ran_Obstacle == 1)
            Curtain_Time();
    }

    //장애물 관련
    public void CameraRotation()
    {
        StartCoroutine("CameraRotation_Coroutine");
    }
    IEnumerator CameraRotation_Coroutine()
    {
        camera.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        for (int i = 0; i < 180; i++)
        {
            camera.gameObject.transform.rotation = Quaternion.Euler(0, 0, i);
            yield return new WaitForSeconds(0.005f);
        }
        camera.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);

        yield return new WaitForSeconds(3f);
        camera.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        obstacle_arr[0] = 0;
    }

    public void Curtain_Time()
    {
        timeCurtain.gameObject.SetActive(true);
        Invoke("Dis_timeCurtain", 5f);
    }

    void Dis_timeCurtain()
    {
        timeCurtain.gameObject.SetActive(false);
        obstacle_arr[1] = 1;
    }
}
