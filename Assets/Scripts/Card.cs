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
        FirstOpenCard(); //���ӽ��۰� ���ÿ� ī�� 1�ʰ� �����ֱ� ���
    }
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
        else if (GameManager.Instance.secondCard == null)
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.Matched();

        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("CardFlip") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 2f)
        {
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
