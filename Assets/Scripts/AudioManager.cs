using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Audio; // �Ҹ� ������ ���� using


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
        audioSource.clip = this.BackGorundMusic; //���
        audioSource.Play();
        


    }
    public void OpenCardSound() //ī�� ���� �Ҹ�
    {
        audioSource.PlayOneShot(OpenSound);
    }

    public void MatchedSound() //ī�� ���⶧ �Ҹ�
    {
        audioSource.PlayOneShot(MactchSound);
    }
    public void MissMatchSound() // ī�� �����⶧ �Ҹ�
    {
        audioSource.PlayOneShot(MissMactchSound);
    }
    public void HurryUp() // ���θ��� �Ҹ�
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

