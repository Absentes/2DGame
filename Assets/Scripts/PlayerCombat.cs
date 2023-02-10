using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackpoint;
    public float attackrange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 40; 

    [SerializeField] private AudioSource Attackeffect;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Attack();
            Attackeffect.Play();
        }
        
    } 
    void Attack()
    {
        //Play the Attack Animation
        animator.SetTrigger("Attack");

        // Detect enemies
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, enemyLayers);

        //Damage Enemies
        foreach(Collider2D skeleton in hitenemies)
        {
            skeleton.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }      
    }

     private void OnDrawGizmosSelected() 
     {
        if (attackpoint == null)
           return;

        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
     }

     
}
