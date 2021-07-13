using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YeniDusman : MonoBehaviour
{
    public Transform hero;
    public bool HareketIzni;
    public float KovalamaHizi;
    public Animator dusmanDeadAnimator;
    bool DusmanDead = false;
    bool beklemede=true ;
    bool saldir = false;
    

    void Start()
    {
        
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
            beklemede = false;
            saldir = true;
            DusmanDead = false;
        }
        dusmanDeadAnimator.SetBool("saldir", saldir);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            saldir = false;
            HareketIzni = false;
            beklemede = true;   
        }
        dusmanDeadAnimator.SetBool("beklemede", beklemede);
    }
    void KarakterKovalama()
    {
        transform.position = Vector3.MoveTowards(transform.position, hero.position, KovalamaHizi * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HareketIzni = false;
            DusmanDead = true;
            dusmanDeadAnimator.SetBool("dusmanOluMu",DusmanDead);
            Destroy(this.gameObject, 5f);

        }
    }
}
