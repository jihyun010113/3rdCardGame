using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip OpenSound;
    public AudioClip MactchSound;
    public AudioClip MissMactchSound;
    public AudioClip BackGorundMusic;
    public AudioClip HurryUpSound;

    AudioSource audioSource;

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

        if (Time.deltaTime < 10.0f) // Time 10�ʹ̸��϶� ������ ���
        {
            audioSource.PlayOneShot(HurryUpSound);
            Destroy(gameObject);
        }
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
        audioSource.PlayOneShot(MactchSound);
    }
}
