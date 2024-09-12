using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Audio; // 소리 조절을 위한 using


public class AudioManager : MonoBehaviour
{

    public AudioMixer masterMixer;
    public Slider audioSlider;
  



    public static AudioManager Instance;

    public AudioClip OpenSound;
    public AudioClip MactchSound;
    public AudioClip MissMactchSound;
    public AudioClip BackGorundMusic;
    public AudioClip HurryUpMusic;
    

    public AudioSource audioSource;

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


    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = this.BackGorundMusic; //브금
        audioSource.Play();
        


    }
    public void OpenCardSound() //카드 열때 소리
    {
        audioSource.PlayOneShot(OpenSound);
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

    public void AudioControl()
    
    {

        DontDestroyOnLoad(gameObject);

        float sound = audioSlider.value;

        if (sound == -40f) masterMixer.SetFloat("Master", -80);
        else masterMixer.SetFloat("Master", sound);
    
    
    }

    public void GameOver()

    {

        audioSource.clip = this.BackGorundMusic;
        audioSource.Play();


    }


    
}

