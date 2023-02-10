using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 40;
    public PlayerHealth playerHealth;
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource damageeffect;
    // Start is called before the first frame update
      
  private void OnCollisionEnter2D(Collision2D collision) 
  {
    if (collision.gameObject.tag == "Player")
    {
      playerHealth.TakeDamage(damage);
      damageeffect.Play();
    }
  }
}
