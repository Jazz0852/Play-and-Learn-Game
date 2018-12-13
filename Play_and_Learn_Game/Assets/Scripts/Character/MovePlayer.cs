using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    Animator animLiam;
    float speed = 5f;
    float stopspeed = 0f;
    Rigidbody playerRB;
    public Joystick joystick;


    // Use this for initialization
    void Start()
    {

        playerRB = GetComponent<Rigidbody>();

        animLiam = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);
        Vector3 stopVector = Vector3.zero;

        if (moveVector != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveVector);
            transform.Translate(moveVector * speed * Time.deltaTime, Space.World);
        }

        if (moveVector != Vector3.zero)
        {
            //Animate Walk
            animLiam.SetBool("Walk", true);
            animLiam.SetBool("Stop", false);
        }

        //Stop Liam Animation
        if (moveVector == Vector3.zero)
        {
            animLiam.SetBool("Walk", false);
            animLiam.SetBool("Stop", true);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(stopVector * stopspeed * Time.deltaTime, Space.World);
            animLiam.SetBool("Walk", false);
            animLiam.SetBool("Stop", true);
        }
       
        /*//Walk Animation Liam
        if (joystick.Horizontal > 0 || joystick.Horizontal < 0 || joystick.Vertical > 0 || joystick.Vertical < 0)
        {
            //Animate Walk
            animLiam.SetBool("Walk", true);
            animLiam.SetBool("Stop", false);

        }

        //Stop Liam Animation
        if (joystick.Horizontal == 0 && joystick.Vertical == 0)
        {
            animLiam.SetBool("Walk", false);
            animLiam.SetBool("Stop", true);
        } */

        /* //Walk Animation Liam
         if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow)
              || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow))
         {
             //Animate Walk
             animLiam.SetBool("Walk", true);
             animLiam.SetBool("Stop", false);

         }

         //Stop Liam Animation
         if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.LeftArrow)
              || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow))
         {
             animLiam.SetBool("Walk", false);
             animLiam.SetBool("Stop", true);
         } */



    }
}

    //void FixedUpdate()
   /* {
        //Move Code

        //Move Player Forward
        if (joystick.Vertical > 0)
        {
            playerRB.AddForce(new Vector3(0, 0, 5), ForceMode.VelocityChange);

            playerRB.rotation = Quaternion.LookRotation(Vector3.forward);
        }

        //Move Player Back
        if (joystick.Vertical < 0)
        {
            playerRB.AddForce(new Vector3(0, 0, -5), ForceMode.VelocityChange);

            playerRB.rotation = Quaternion.LookRotation(Vector3.back);

        }

        //Move Player Left
        if (joystick.Horizontal < 0)
        {
            //Move Player
            playerRB.AddForce(new Vector3(-5, 0, 0), ForceMode.VelocityChange);

            playerRB.rotation = Quaternion.LookRotation(Vector3.left);
        }

        //Move Player Right
        if (joystick.Horizontal > 0)
        {
            //Move Player
            playerRB.AddForce(new Vector3(5, 0, 0), ForceMode.VelocityChange);

            playerRB.rotation = Quaternion.LookRotation(Vector3.right);
        }
    }
} */
            /*//Move Code

            //Move Player Forward
            if (Input.GetKey(KeyCode.UpArrow))
            {
                playerRB.AddForce(new Vector3(0, 0, 5), ForceMode.VelocityChange);

                playerRB.rotation = Quaternion.LookRotation(Vector3.forward);
            }

            //Move Player Back
            if (Input.GetKey(KeyCode.DownArrow))
            {
                playerRB.AddForce(new Vector3(0, 0, -5), ForceMode.VelocityChange);

                playerRB.rotation = Quaternion.LookRotation(Vector3.back);

            }

            //Move Player Left
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //Move Player
                playerRB.AddForce(new Vector3(-5, 0, 0), ForceMode.VelocityChange);

                playerRB.rotation = Quaternion.LookRotation(Vector3.left);
            }

            //Move Player Right
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //Move Player
                playerRB.AddForce(new Vector3(5, 0, 0), ForceMode.VelocityChange);

                playerRB.rotation = Quaternion.LookRotation(Vector3.right);
            }*/
//}
