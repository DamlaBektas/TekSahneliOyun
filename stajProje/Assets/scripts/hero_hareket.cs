using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class hero_hareket : MonoBehaviour
{
    public GameObject HikayePanel1;
    public GameObject HikayePanel2;
    public bool hikayeMi = false;
    private Rigidbody2D rb;
    private bool moveLeft;
    private bool moveRight;
    private float horizantalMove;
    private float speed = 3;
    public float jumpSpeed = 3;
    bool isAttacking;

    public AudioSource coin_toplama_sesi;
    public AudioSource sandik_sesi;
    public AudioSource kilic_sesi;
    public AudioSource engel_sesi;
    public AudioSource olme_sesi;
    public AudioSource kapisesi;

    public GameObject AcikKol;
    public GameObject AcikKapi;
    public GameObject KapaliKapi;
    public int saglik;
    public GameObject kalp1;
    public GameObject kalp2;
    public GameObject kalp3;
    public int tas_sayisi;
    public Text tas_sayisi_text;
    public Text son_toplanan_tas;
    public bool oyunbasladimi=false;
    public GameObject oyunbasi;
    public GameObject oyunSonuKaybet;
    public GameObject oyunSonuKazan;
    public bool Button = false;
    
    public int DusmanSayisi;
    public GameObject dusman1;
    public GameObject dusman2;
    public GameObject dusman3;
    public GameObject dusman4;
    public GameObject dusman5;
    public GameObject dusman6;
    public GameObject bilgiPanel;

    public int AnahtarSayisi = 0;
    public AudioSource AnahtarSesi;
    public GameObject IlkAcikKapi;
    public GameObject IlkKapaliKapi;
    public GameObject AnahtarUyariPaneli;

    public bool OyunDurduMU=false;

    bool jump = false;
    bool attack = false;
    public Animator benim_animator;
    bool dead = false;



    void Start()
    {
        HikayePanel1.SetActive(true);
        HikayePanel2.SetActive(false);
        bilgiPanel.SetActive(false);
        dusman1.SetActive(true);
        dusman2.SetActive(true);
        dusman3.SetActive(true);
        dusman4.SetActive(true);
        dusman5.SetActive(true);
        dusman6.SetActive(true);
        AnahtarUyariPaneli.SetActive(false);
        IlkAcikKapi.SetActive(false);
        IlkKapaliKapi.SetActive(true);

        if (oyunbasladimi == true)
        {
            oyunbasi.SetActive(false);
        }
        else
        {
            oyunbasi.SetActive(true);
        }
        rb = GetComponent<Rigidbody2D>();
        
        moveLeft = false;
        moveRight = false;
        AcikKol.gameObject.SetActive(false);
        AcikKapi.gameObject.SetActive(false);
        KapaliKapi.gameObject.SetActive(true);
        kalp1.gameObject.SetActive(true);
        kalp2.gameObject.SetActive(true);
        kalp3.gameObject.SetActive(true);
        oyunSonuKaybet.gameObject.SetActive(false);
        oyunSonuKazan.gameObject.SetActive(false);

    }
    public void PointerDownLeft()
    {
        moveLeft = true;
    }
    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    public void PointerDownRight()
    {
        moveRight = true;
    }
    public void PointerUpRight()
    {
        moveRight = false;
    }

    public void PointerDownJump()
    {
        jump = true;
    }
    public void PointerUpJump()
    {
        jump = false;
    }
    public void PointerDownnAttack()
    {
        attack = true;
        kilic_sesi.Play();
    }
    public void PointerUpAttack()
    {
        attack = false;
    }
    
    void Update()
    {
    }

    public void Attack()
    {
        if (isAttacking == false)
        {
            isAttacking = true;

        }
    }
    void MovementPlayer()
    {
        if (oyunbasladimi == false)
        {
            return;
        }
        if (moveLeft)
        {
            horizantalMove = -speed;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveRight)
        {
            horizantalMove = speed;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            horizantalMove = 0;
        }

        if(jump == true)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            benim_animator.SetBool("jump", jump);
        }
        else
        {
            benim_animator.SetBool("jump", jump);
        }
        benim_animator.SetBool("saldýr", attack);
    }

    private void FixedUpdate()
    {
        bool kos = false;

        MovementPlayer();

        rb.velocity = new Vector2(horizantalMove, rb.velocity.y);

        if (horizantalMove != 0)
        {
            kos = true;
        }

        if (horizantalMove == 0)
        {
            kos = false;
        }
        benim_animator.SetBool("kos", kos);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
         if (collision.tag == "coin")
         {
            tas_sayisi++;
            tas_sayisi_text.text = tas_sayisi.ToString();
            son_toplanan_tas.text = tas_sayisi.ToString();
            Destroy(collision.gameObject);
            coin_toplama_sesi.Play();
         }
         if (collision.tag == "sandik")
         {
            tas_sayisi += 10;
            tas_sayisi_text.text = tas_sayisi.ToString();
            sandik_sesi.Play();
            Destroy(collision.gameObject);
         }
         if (collision.tag == "kol")
         {
            Destroy(collision.gameObject);
            AcikKol.gameObject.SetActive(true);
            KapaliKapi.gameObject.SetActive(false);
            AcikKapi.gameObject.SetActive(true);
            kapisesi.Play();
         }
         if (collision.tag == "anahtar")
         {
            AnahtarSayisi++;
            Destroy(collision.gameObject);
            AnahtarSesi.Play();
         }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "kapi" && AnahtarSayisi == 6)
        {
            IlkAcikKapi.SetActive(true);
            IlkKapaliKapi.SetActive(false);
            kapisesi.Play();
        }
        
        else if (collision.gameObject.tag == "kapi" && AnahtarSayisi != 6)
        {
            AnahtarUyariPaneli.SetActive(true);
            Time.timeScale = 0f;
        }

        if (collision.gameObject.tag=="engel")
        {
            engel_sesi.Play();
            saglik -= 20;
            if (saglik==40)
            {
                kalp1.SetActive(false);
            }
            if (saglik == 20)
            {
                kalp2.SetActive(false);
            }
            if (saglik == 0)
            {
                kalp3.SetActive(false);
                dead = true;
                benim_animator.SetBool("dead", dead);
                oyunSonuKaybet.gameObject.SetActive(true);
                olme_sesi.Play(10);
                //Camera.main.transform.parent = null;
            }
              
        }
        if (collision.gameObject.tag == "su")
        {
            dead = true;
            benim_animator.SetBool("dead", dead);
            oyunSonuKaybet.gameObject.SetActive(true);
            olme_sesi.Play();
        }
        if (collision.gameObject.tag == "dusman")
        {
            DusmanSayisi++;
            if (DusmanSayisi == 1)
            {
                dusman1.SetActive(false);
            }
            if (DusmanSayisi == 2)
            {
                dusman2.SetActive(false);
            }
            if (DusmanSayisi == 3)
            {
                dusman3.SetActive(false);
            }
            if (DusmanSayisi == 4)
            {
                dusman4.SetActive(false);
            }
            if (DusmanSayisi == 5)
            {
                dusman5.SetActive(false);
            }
            if (DusmanSayisi == 6)
            {
                dusman6.SetActive(false);
                bilgiPanel.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
    public void OyunDurdur()
    {
        if (OyunDurduMU == true)
        {
            Time.timeScale = 1f;
            OyunDurduMU = false;
            bilgiPanel.SetActive(false);
            AnahtarUyariPaneli.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            OyunDurduMU = true;
        }
    }
    public void oyunbasladý()
    {
        oyunbasladimi=true;
        oyunbasi.SetActive(false);
    }
    public void hikaye_panel1()
    {
        hikayeMi = true;
        HikayePanel1.SetActive(false);
        HikayePanel2.SetActive(true);
    }
    public void hikaye_panel2()
    {
        HikayePanel2.SetActive(false);
    }
}
