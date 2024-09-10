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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ImageSetting(int number)
    {
        frontImage.sprite = randomImages[number];
    }
    public void OpenCard()
    {
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);
    }
    public void CloseCard()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}
