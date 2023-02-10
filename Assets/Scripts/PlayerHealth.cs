using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int MaxHealth = 100;
    public int health;
     private Animator anim;
    private Rigidbody2D rb;

    public HealthBar healthBar;

    [SerializeField]  private AudioSource Deatheffect; 
    [SerializeField] private AudioSource hurteffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }
      public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
        Deatheffect.Play();
        
    }
    public void TakeDamage(int damage)
    {
       health -= damage;
       anim.SetTrigger("isHurt");
       healthBar.sethealth(health); 
       hurteffect.Play();
       
       if (health <= 0)
       {
          Die();
       }      
    }
    // Start is called before the first frame update
     private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
           Die(); 
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

