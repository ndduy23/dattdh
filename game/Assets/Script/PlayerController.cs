using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//dung UI
using UnityEngine.SceneManagement;//scene
using TMPro;

public class PlayerController : MonoBehaviour
{
    //Variables
    private Rigidbody2D rb;
    private Animator move;  // di chuyen
    private Collider2D coll;
    
    //State
    private enum State { idle, running, jumping, falling, hurt}// cho phep kiem soat trang thai voi tung trang thai = 0,1,2
    private State state = State.idle;
    // test
    [SerializeField] private string SceneName;
    //Inspector variables
    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jump = 10f;
    [SerializeField] private TextMeshProUGUI cherryText;
    [SerializeField] private float hurtForce = 10f;
    //Heart
    [SerializeField] private float health = 4f;
    [SerializeField] private float numOfHeart = 4f;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
   //jumpcheck
    [SerializeField] private Transform CanJump;
    //trap
    [SerializeField] private float hurtX;
    [SerializeField] private float hurtY;
    //fx    
    [SerializeField] private AudioSource footstep;
    [SerializeField] private AudioSource cherry;
    [SerializeField] private AudioSource jumpfx;
    [SerializeField] private AudioSource fallfx;
    [SerializeField] private AudioSource music;
    //check
    private bool isGrounded;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        move = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
       
    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(CanJump.position, .5f, ground); 
        if (state != State.hurt)
        {
            Movement();
        }
        VelocityState();
        move.SetInteger("stage", (int)state);
        //test
        Health();
        Heart();
        if(health == 0)
        {
            SceneManager.LoadSceneAsync("game over");
        }
      
    }
    
    
    private void Health()
    {      
        if (health == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            health += 4;         
        }
    }  

    private void OnTriggerEnter2D(Collider2D collision)//Va cham voi tag
    {
        if(collision.tag == "Collectable")//Cherrie
        {
            cherry.Play();
            Destroy(collision.gameObject);
            PermanetUI.perm.cherries += 1;
            PermanetUI.perm.cherryText.text = PermanetUI.perm.cherries.ToString();//chuyen cherries sang string de co the tuong thich            
        }
        if(collision.tag == "PowerUp")
        {
            Destroy(collision.gameObject);
            speed = 15f;
            jump = 25f;
            GetComponent<SpriteRenderer>().color = Color.yellow;
            StartCoroutine(ResetPower());
        }
        if (collision.tag == "Trap")
        {
            state = State.hurt;
            health -= 1;
            if (IsFacingRight())
            {

                rb.velocity = new Vector2(hurtX, hurtY);
            }
            else
            {

                rb.velocity = new Vector2(-hurtX, hurtY);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Forg frog = other.gameObject.GetComponent<Forg>(); // lay tham chieu voi Forg
            if (state == State.falling)
            {
                frog.JumpOn();
                Jump();
            }   
            else// State hurt
            {
                state = State.hurt;
                health -= 1;            
                if (other.gameObject.transform.position.x > transform.position.x)
                {

                    rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
                }
                else
                {
            
                    rb.velocity = new Vector2(hurtForce, rb.velocity.y);
                }

              
            }
        }
    }
    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }
    private void Heart()
    {
        if(health > numOfHeart)
        {
            health = numOfHeart;
        }
        for(int i = 0;i< hearts.Length; i++)
        {
            if(i< health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if( i<numOfHeart)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void Movement()
    {
        float hDirection = Input.GetAxisRaw("Horizontal");//su dung axis cong cu setup phim co trong unity
        if (hDirection < 0)// Nhan A de di chuyen sang trai
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);//vector(x, y) voi x la truc x va y la truc y
            transform.localScale = new Vector2(-1, 1);
        }
        else if (hDirection > 0)// Nhan D de di sang phai
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetButtonDown("Jump") && isGrounded)//kiem soat khi nao nhan vat nhay)
        {
            Jump();
        }

    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jump);
        state = State.jumping;
    }    
    private void VelocityState()// ham theo doi cho biet trang thai nhan vat
    {
        if (state == State.jumping)
        {
            if (rb.velocity.y < .1f)// neu toc do truc y nho hon 0.1f thi chuyen sang trnag thai roi
            {
                state = State.falling;
            }
        }
        else if (state == State.falling)// trnag thai roi
        {
            if (isGrounded)// neu coll cham vao ground thi nhan vat vao trnag thai tinh(coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if (state == State.hurt)
        {

            if (Mathf.Abs(rb.velocity.x) < .001f)
            {
                state = State.idle;

            }            
        }
        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            // di sang phai
            state = State.running;
           
        }
        else
        {
            //dung im
            state = State.idle;           
        }
        
    }
    private IEnumerator ResetPower()
    {
        yield return new WaitForSeconds(6);
        speed = 7f;
        jump = 15f;
        GetComponent<SpriteRenderer>().color = Color.white;

    }
    private void Footstep()
    {
        footstep.Play();
    }
    private void Jumpfx()
    {
        jumpfx.Play();
    }
    private void Fallfx()
    {
        fallfx.Play();
    } 
    private void MusicFx()
    {
        music.Play();
    }    
    
}


