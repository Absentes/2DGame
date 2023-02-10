using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatedMovement : MonoBehaviour
{

public CharacterController controller;

float Horizontal = 40f;
bool jump = false;
float runspeed = 40f;


    // Update is called once per frame
    void Update()
    {
       Horizontal =  Input.GetAxisRaw("Horizontal");

       if (Input.GetButtonDown("Jump"))
       {
           jump = true;
       }
    }

    void FixedUpdate()
    {
      controller.Move(Horizontal * Time.fixedDeltaTime, false, jump);
      jump = false;
    }

}
