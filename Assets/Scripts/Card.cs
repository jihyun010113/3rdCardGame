using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        else
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.Matched();

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
