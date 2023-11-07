using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 20f;
    public float movementX;
   [SerializeField] private Rigidbody2D horse;
    private BoxCollider2D horseBox;
    private SpriteRenderer render;
    private Animator anim;
    private string Run = "run";
    private string Jump = "jump";
    private string Idle = "idle";
    private bool groundHit = false;
    private bool DoubleJump = false;
    [SerializeField] private int health = 100;
    [SerializeField] private int maxHealth = 100;
    public Health healthBar;
    private bool died = false;
    [SerializeField] private AudioSource jumpAudio;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        horse = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        horseBox = GetComponent<BoxCollider2D>();

    }
    void Start()
    {
        healthBar.setMax(maxHealth);
    }

    void Update()
    {
        PLayerMoveKeyboard();
        AnimateHorse();
        PlayerJump();
       
    }
   
    void PLayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * speed;
       
    }
    void AnimateHorse()
    {
        if(movementX > 0 && !groundHit)
        {
            anim.SetBool(Run, true);
            anim.SetBool(Jump, false);
            anim.SetBool(Idle, false);
            render.flipX = false;
        }
        else if (movementX < 0 && !groundHit)
        {
            anim.SetBool(Run, true);
            anim.SetBool(Jump, false);
            anim.SetBool(Idle, false);

            render.flipX = true;
        }
        else if(groundHit)
        {
            anim.SetBool(Run, false);
            anim.SetBool(Jump, true);
            anim.SetBool(Idle, false);
            if(movementX > 0)
            {
                render.flipX = false;
            }
            else if(movementX < 0)
            {
                render.flipX = true;
            }
        }
        else
        {
            anim.SetBool(Run, false);
            anim.SetBool(Jump, false);
            anim.SetBool(Idle, true);
        }
    }
    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !groundHit)
        {
            jumpAudio.Play();
            groundHit = true;
            Debug.Log("pressed");
            horse.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        //if(Input.GetKeyDown(KeyCode.Space) && groundHit && !DoubleJump)
        //{
        //    DoubleJump = true;
        //    horse.AddForce(new Vector2(0f,5f), ForceMode2D.Impulse);
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
           DoubleJump = false;
            groundHit = false;
            //Debug.Log("touched");
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Debug.Log("touched coin");
        }
    }
    public void Damaged(int damage)
    {
        if (health <= 5)
        {
            die();
        }
        if (health > 0)
        {
            anim.SetTrigger("hurt");
            health = health - damage;
            healthBar.setHealth(health);
        }
       
    }
    void die()
    {
        anim.SetBool("isdead", true);
        anim.SetBool(Idle, false);
        died = true;
        //GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
    public float returnMovementX()
    {
        return movementX;
    }
    
} //class
