using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovB : MonoBehaviour   
{

    public CharacterController2D control;
    public float runSpeed = 20f;
    float hMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        

        hMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch")) {
            crouch = false;
        }

    }



    void FixedUpdate()
    {
        control.Move(hMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
