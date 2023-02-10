using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float Horizontal;
    private float speed = 3f;
    public Animator Animator;
    public int maxhealth = 100;
    public int currenthealth;
    Rigidbody2D EnemyBody;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;
        EnemyBody = GetComponent<Rigidbody2D>();
    }

    void update()
    {
      Horizontal =  Input.GetAxisRaw("Horizontal");
      Animator.SetFloat("Speed", Mathf.Abs(Horizontal)); 
        
    if (isfacingright())
    {
        //Move Right
        EnemyBody.velocity = new Vector2(speed, 0f);
    }
    else 
    {
        //Move Left
        EnemyBody.velocity = new Vector2(-speed, 0f);
    }
    }


    public void TakeDamage(int Damage)
    {
        currenthealth -=Damage;

        //animation (Hurt)
        Animator.SetTrigger("Hurt");

        if(currenthealth <= 0)
        { 
            
            Die();
            speed = 0f;
 
        }
    }

    void Die()
    {
        //Die animation

        Debug.Log("Enemy Died");

        Animator.SetBool("Dead", true);

        //Disable The Enemy
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        this.enabled = false;
        speed = 0f;    
    
    }
    private bool isfacingright()
  {
     return transform.localScale.x > Mathf.Epsilon;
  }
  
  private void OnTriggerEnter2D(Collider2D collision) 
  {
    transform.localScale = new Vector2(- (Mathf.Sign(EnemyBody.velocity.x)), transform.localScale.y);
  }
}

