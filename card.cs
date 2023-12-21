using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class card : MonoBehaviour
{
    public Animator anim;

    public int Type = 0;

    public AudioClip flips;
    public AudioSource audioSource;

    public GameObject NameText;
    public GameObject FailText;

    public Text Name;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Type == 0 || Type == 1)
            Name.text = "�赿ȯ";
        else if (Type == 2 || Type == 3)
            Name.text = "�����";
        else if (Type == 4 || Type == 5)
            Name.text = "��ö��";
        else if (Type == 6 || Type == 7)
            Name.text = "������";
        else if (Type == 8 || Type == 9)
            Name.text = "������B";
    }

    public void openCard()
    {
        audioSource.PlayOneShot(flips);
        anim.SetBool("isOpen", true);

        Invoke("flip", 0.3f);

        if (GameManager.I.firstCard == null)
        {
            GameManager.I.firstCard = gameObject;
        }
        else
        {
            GameManager.I.secondCard = gameObject;
            GameManager.I.isMatched();
        }
    }
    void flip()
    {
        transform.Find("front").gameObject.SetActive(true);
        transform.Find("back").gameObject.SetActive(false);
    }

    public void destroyCard()
    {
        NameText.SetActive(true);
        Invoke("destroyCardInvoke", 1f);
    }

    void destroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void closeCard()
    {
        FailText.SetActive(true);
        Invoke("closeCardInvoke", 0.5f);
    }

    void closeCardInvoke()
    {
        FailText.SetActive(false);
        anim.SetBool("isOpen", false);
        transform.Find("back").gameObject.SetActive(true);
        transform.Find("front").gameObject.SetActive(false);
    }
}
