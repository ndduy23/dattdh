using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forg : Enemy//Forg ke thu Enemy
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;
    [SerializeField] private Transform CanJump;
    [SerializeField] private float jumpLength = 3f;
    [SerializeField] private float jumpStreng = 4f;
    [SerializeField] private LayerMask Ground;
    private Collider2D coll;
    private bool facingLeft = true;
    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {     
        if (anim.GetBool("jump"))
        {
            if (rb.velocity.y < .1)// kiem tra xem enemy co dang roi ko
            {
                anim.SetBool("fall", true);
                anim.SetBool("jump", false);
            }
        }//chuyen tu jumo ve idle
        if (coll.IsTouchingLayers(Ground)&& anim.GetBool("fall"))//chuyen tu jumo ve idle
        {
            anim.SetBool("fall", false);
        }
      
    }

    private void Moving()
    {
        if (facingLeft)
        {
            //Kiem tra xem neu vuot qua leftCap
            if (transform.position.x > leftCap)
            {
                //ktra neu con ech tram mat dat thi tiep tuc nhay
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }
                if (coll.IsTouchingLayers(Ground))
                {
                    //jump
                    rb.velocity = new Vector2(-jumpLength, jumpStreng);
                    anim.SetBool("jump", true);
                }
            }
            else
            {
                facingLeft = false;
            }
            //neu no ko vuot qua thi quay sang phai
        }
        else
        {
            if (transform.position.x < rightCap)
            {
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }
                if (coll.IsTouchingLayers(Ground))
                {
                    //jump
                    rb.velocity = new Vector2(jumpLength, jumpStreng);
                    anim.SetBool("jump", true);
                }
            }
            else
            {
                facingLeft = true;
            }

        }
    }
   

}

