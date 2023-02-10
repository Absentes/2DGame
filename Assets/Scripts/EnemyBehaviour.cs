using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
   float movespeed = 1f;

   Rigidbody2D EnemyBody;
  void Start()
  {
    EnemyBody = GetComponent<Rigidbody2D>();

  }
  void Update()
  {
    if (isfacingright())
    {
        //Move Right
        EnemyBody.velocity = new Vector2(movespeed, 0f);
    }
    else 
    {
        //Move Left
        EnemyBody.velocity = new Vector2(-movespeed, 0f);
    }
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
