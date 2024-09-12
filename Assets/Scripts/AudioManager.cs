using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio; // 소리 조절을 위한 using
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{

    public AudioMixer masterMixer;
    public Slider audioSlider;


    public bool isplaying;

    public static AudioManager Instance;

    public AudioClip MactchSound;
    public AudioClip MissMactchSound;
    public AudioClip BackGorundMusic;
    public AudioClip HurryUpMusic;
    public AudioClip GamePlaySound;
    public AudioClip EndPanelSound;

    public int sceneIndex;


    public AudioSource audioSource;

    public float sound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }

        // 스타트에서는 한번실행되고 끝나는데 씬변경이랑 무관하게 한번만 실행됨
        // 씬을 변경해도 안됌 >> 파괴하고 다시만들어야함
        // 씬변경코드랑 BGM코드를 동시에 햇는데 안됏던이유는 
        // BGM을 변경하는 코드는 속도가 빠르다. 씬변경은 속도가 느려서 
        // 브금은 인덱스를 가져와서 씬변경이 되야하는데 씬변경 속도가 느려서 인덱스를 못가져와서
        //  안됌
    }

    public void ChangeBGM(int SceneName)
    {
        audioSource = GetComponent<AudioSource>();
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(sceneIndex);
        if (SceneName == 0)
        {
            audioSource.clip = this.BackGorundMusic;
            Debug.Log("if");
        }
        else
        {
            audioSource.clip = this.GamePlaySound;
            Debug.Log("else");
        }
        audioSource.Stop();
        audioSource.Play();
    }
    void Start()
    {
        ChangeBGM(0);
    }
    public void MatchedSound() //카드 맞출때 소리
    {
        audioSource.PlayOneShot(MactchSound);
    }
    public void MissMatchSound() // 카드 못맞출때 소리
    {
        audioSource.PlayOneShot(MissMactchSound);
    }
    public void HurryUp() // 서두를때 소리
    {

        audioSource.PlayOneShot(HurryUpMusic);

    }

    /*public void AudioControl()
    
    {

        sound = audioSlider.value;

        if (sound == -40f) masterMixer.SetFloat("Master", -80);
        else masterMixer.SetFloat("Master", sound);
    
    
    }*/

    public void GameOver()

    {

        audioSource.clip = this.BackGorundMusic;
        audioSource.Play();


    }


    
}

