using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator anim;//cho lop ke thua truy cap vao dong lenh
    protected Rigidbody2D rb;
    protected AudioSource deathsound;
    protected virtual void Start()//
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        deathsound = GetComponent<AudioSource>();
    }
    public void JumpOn()
    {
        anim.SetTrigger("Death");// thuc hien animation Death
        deathsound.Play();
        rb.velocity = Vector2.zero;
    }
    private void Death()
    {    
        Destroy(this.gameObject);
    }
}
