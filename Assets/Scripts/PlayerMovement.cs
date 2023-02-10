using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

   public CharacterController controller;
    
    private float Horizontal;
    private float speed = 3f;
    private float jumping_power = 15f;
    private bool isfacingright = true; 
    bool Jump = false;
    

    public Animator Animator;

[SerializeField] private Rigidbody2D rbody; 
[SerializeField] private Transform groundcheck;
[SerializeField] private LayerMask groundlayer;     
[SerializeField] private AudioSource JumpEffect;
[SerializeField] private AudioSource collectioneffect;

    void Update()
    {
         Horizontal =  Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            JumpEffect.Play();
            rbody.velocity = new Vector2(rbody.velocity.x, jumping_power);
        }

        if (Input.GetButtonUp("Jump") && rbody.velocity.y > 0f)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, rbody.velocity.y * 0.5f );
            Animator.SetBool("IsJumping", true);
        }

        Flip();

        Animator.SetFloat("Speed", Mathf.Abs(Horizontal));

        if (Input.GetButtonDown("Jump"))
        {
            Jump = true;
            Animator.SetBool("IsJumping", true);
        }
    }

    
     void OnTriggerEnter2D(Collider2D other)
      {
        if (other.gameObject.CompareTag("Coin"))
        {
            collectioneffect.Play();
            Destroy(other.gameObject); 
        }
      }

      void Falling()
      {
        if (rbody.velocity.y < 0)
        {
         Animator.SetBool("IsJumping", false);
         Animator.SetBool("Falling", true);
        }
        if (rbody.velocity.y == 0)
        {
         Animator.SetBool("IsJumping", false);
         Animator.SetBool("Falling", false);
        }
       
;     }


    private void FixedUpdate() 
    {
      rbody.velocity = new Vector2(Horizontal * speed, rbody.velocity.y);  
    }

    private void Flip()
    {
        if (isfacingright && Horizontal < 0f || !isfacingright  && Horizontal > 0f)
        {
            isfacingright = !isfacingright;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundlayer);
    }

   public void Onlanding ()
    {
         Animator.SetBool("IsJumping", false);
    }
    
}
