using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxhealth = 100;
    int currenthealth;
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;
    }

    public void TakeDamage(int Damage)
    {
        currenthealth -=Damage;

        if(currenthealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Die animation

        Debug.Log("Enemy Died");

        //Disable The Enemy
        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        
    }
}
