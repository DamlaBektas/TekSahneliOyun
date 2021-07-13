using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kiz_takip : MonoBehaviour
{
    public Transform hero;
    public bool HareketIzni;
    public float KovalamaHizi;
    public Animator kız_anim;
    bool yurume = false;
    public AudioSource kazanmaSesi;
    public GameObject oyun_sonu_kazan;


    void Start()
    {
        oyun_sonu_kazan.gameObject.SetActive(false);
    }

    void Update()
    {
        if (HareketIzni)
        {
            KarakterKovalama();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            HareketIzni = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            HareketIzni = false;
        }
    }
    void KarakterKovalama()
    {
        transform.position = Vector3.MoveTowards(transform.position, hero.position, KovalamaHizi * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            oyun_sonu_kazan.gameObject.SetActive(true);
            HareketIzni = false;
            yurume = true;
            kız_anim.SetBool("yurusunMu", yurume);
            kazanmaSesi.Play();
        }
    }
}

