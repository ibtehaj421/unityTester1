using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private float attackRate = 2f;
    private float attackTime = 0f;
    [SerializeField] private GameObject enemy;
    [SerializeField] private AudioSource attackSound;
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= attackTime)
        { 
            if (Input.GetKeyDown(KeyCode.C))
            {
                attackSound.Play();
                Attack();
                attackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        //the attack animation
        animator.SetTrigger("attack");

        //collision detection using a gizmo
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position , attackRange,enemyLayers);

        //damage dealth
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<enemyBehaviour>().Damaged(60);
            //Debug.Log("We hit" +  enemy.name);
            
        }

    }
    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
