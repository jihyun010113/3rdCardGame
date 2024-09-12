using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio; // �Ҹ� ������ ���� using
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

        // ��ŸƮ������ �ѹ�����ǰ� �����µ� �������̶� �����ϰ� �ѹ��� �����
        // ���� �����ص� �ȉ� >> �ı��ϰ� �ٽø�������
        // �������ڵ�� BGM�ڵ带 ���ÿ� �޴µ� �ȉѴ������� 
        // BGM�� �����ϴ� �ڵ�� �ӵ��� ������. �������� �ӵ��� ������ 
        // ����� �ε����� �����ͼ� �������� �Ǿ��ϴµ� ������ �ӵ��� ������ �ε����� �������ͼ�
        //  �ȉ�
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

