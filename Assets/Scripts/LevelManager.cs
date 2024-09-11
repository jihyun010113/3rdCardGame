using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//레벨메니저
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int match_cnt;

    public int[] obstacle_arr;
    public GameObject timeCurtain;
    public Camera camera;
    public GameObject crow;
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
        obstacle_arr = new int[3] { 0, 1, 2 };
    }

    public void Match_CntUp()
    {
        //asdf
        match_cnt++;
        if (match_cnt >= 2)
        {
            if(obstacle_arr[0] != 100 || obstacle_arr[1] != 100 || obstacle_arr[2] != 100)
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
            ran_Obstacle = Random.Range(0, 3);
        } while (obstacle_arr[ran_Obstacle] == 100);

        obstacle_arr[ran_Obstacle] = 100;

        if (ran_Obstacle == 0)
            CameraRotation();
        else if (ran_Obstacle == 1)
            Curtain_Time();
        else if (ran_Obstacle == 2)
            Crow();
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

    public void Crow()
    {
        crow.gameObject.SetActive(true);
        Invoke("Dis_Crow", 4f);
    }
    void Dis_Crow()
    {
        crow.gameObject.SetActive(false);
        obstacle_arr[2] = 2;
    }
}
