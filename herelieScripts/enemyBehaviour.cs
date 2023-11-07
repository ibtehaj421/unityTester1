using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    
    private string Idle = "idle";
    public Animator animator;
    public Transform attackPoint;
    public float detectionRange;
    public float attackRange = 0.5f;
    public LayerMask PlayerLayer;
    public SpawnBehaviour limit;
    bool detected = true;
    //private Transform player;
    [SerializeField] private float attackTimer;
    private float coolDownTimer = Mathf.Infinity;
    [SerializeField] private BoxCollider2D enemyCollider;
    [SerializeField] private float colliderDistance;
    [SerializeField] private movement player;
    [SerializeField] private float health = 100;
    [SerializeField] private float maxHealth = 100;
    private bool died = false;
    [SerializeField] private int damage = 10;
    private float deathTimer = 50;
    //private float justTimer;
    // Start is called before the first frame update
    void Start()
    {
       // player = GameObject.FindWithTag("samurai").transform;
    }
   
    // Update is called once per frame
    void Update()
    {   
        if(health <= 0)
        {
            die();
        }
        if (!died)
        {
            coolDownTimer += Time.deltaTime;
            if (detectPlayer())
            {
                if (coolDownTimer >= attackTimer)
                {
                    EnemyAttack();
                    coolDownTimer = 0;
                }
            }
        }
        
    }
    void EnemyAnimations()
    {

    }
    void EnemyAttack()
    {
        animator.SetTrigger("attack");
    }
    private void OnDrawGizmosSelected()
    {   
        Gizmos.color = Color.red;
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireCube(enemyCollider.bounds.center + transform.right * detectionRange  * transform.localScale.x * -1f * colliderDistance, new Vector3(enemyCollider.bounds.size.x * detectionRange,enemyCollider.bounds.size.y,enemyCollider.bounds.size.z));
    }
    bool detectPlayer()
    {
        RaycastHit2D hit = Physics2D.BoxCast(enemyCollider.bounds.center + transform.right * detectionRange  * transform.localScale.x * -1f * colliderDistance, new Vector3(enemyCollider.bounds.size.x * detectionRange, enemyCollider.bounds.size.y, enemyCollider.bounds.size.z), 0, Vector2.left,0,PlayerLayer);
       if(hit.collider != null)
        {
            player = hit.transform.GetComponent<movement>();
        }
        return hit.collider != null;
    }
    public void Damaged(int damage)
    {
        //play death animation
        if (health <= 20)
        {
            die();
        }
        //play damage animation
        else if (health > 0)
        {
            health = health - damage;
            animator.SetTrigger("hurt");
        }
    }
    private void damagedPlayer()
    {
        if (detectPlayer())
        {
            player.Damaged(damage);
        }
    }
   void die()
    {
        limit.limiter++;
        Debug.Log("this is the limter value from death: " + limit.limiter);
        animator.SetBool("isdead", true);
        animator.SetBool(Idle, false);
        died = true;
        GetComponent<Collider2D>().enabled = false;
       // this.enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("deleteEnemy"))
        {
            limit.limiter++; 
            Debug.Log("this is the limter value from collider: " + limit.limiter);
            Destroy(this.gameObject);
           
        }
    }
   
}
