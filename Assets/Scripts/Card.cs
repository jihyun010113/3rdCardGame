using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor.Experimental.GraphView;

public class Card : MonoBehaviour
{
    public int idx = 0;
    public SpriteRenderer frontImage;
    public Sprite[] randomImages;
    public GameObject front;
    public GameObject back;
    public Animator anim;

    AudioSource audioSource;
    public AudioClip clip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        FirstOpenCard(); //게임시작과 동시에 카드 1초간 보여주기 기능
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ImageSetting(int number)
    {
        idx = number;
        frontImage.sprite = randomImages[idx];
    }
    public void FirstOpenCard()
    {
        front.SetActive(true);
        back.SetActive(false);
        Invoke("FirstCloseCard", 1f);
    }
    public void FirstCloseCard()
    {
        front.SetActive(false);
        back.SetActive(true);
    }
    public void OpenCard()
    {
        audioSource.PlayOneShot(clip);
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        else if(GameManager.Instance.secondCard == null)
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.Matched();
        }       
        else if (GameManager.Instance.secondCard != null)
        {
            anim.SetBool("isOpen", false);
            front.SetActive(false);
            back.SetActive(true);
        }
    }
    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 0.5f);
    }
    public void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }
    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }
    public void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }

}
