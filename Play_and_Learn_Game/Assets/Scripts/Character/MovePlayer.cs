using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MovePlayer : MonoBehaviour
{

    Animator animLiam;
    float speed = 10.0f;
    Rigidbody playerRB;
    public Joystick joystick;
    public float Hinput;
    public float Vinput;

    // Use this for initialization
    void Start()
    {

        playerRB = GetComponent<Rigidbody>();

        animLiam = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Read Input
        float Hinput = Input.GetAxis("Hinput");
        float Vinput = Input.GetAxis("Vinput");

        //Walk Animation Liam
        if (Hinput != 0 && Vinput != 0)
        {
            //Animate Walk
            animLiam.SetBool("Walk", true);
            animLiam.SetBool("Stop", false);

        }

        //Stop Liam Animation
        if (Hinput == 0 && Vinput == 0)
        {
            animLiam.SetBool("Walk", false);
            animLiam.SetBool("Stop", true);
        }

        /* 
        //Animation with Buttons
        //Walk Animation Liam
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
        }    
        */
    }

    void FixedUpdate()
    {
        //Move code

        //Move player forwards
        if (Hinput > 0)
        {
            playerRB.AddForce(new Vector3(0, 0, 5), ForceMode.VelocityChange);

            playerRB.rotation = Quaternion.LookRotation(Vector3.forward);
        }

        //Move player backwards
        if (Hinput < 0)
        {
            playerRB.AddForce(new Vector3(0, 0, -5), ForceMode.VelocityChange);

            playerRB.rotation = Quaternion.LookRotation(Vector3.back);
        }

        //Move player left
        if (Vinput < 0)
        {
            playerRB.AddForce(new Vector3(-5, 0, 0), ForceMode.VelocityChange);

            playerRB.rotation = Quaternion.LookRotation(Vector3.left);
        }

        //Move player right
        if (Vinput > 0)
        {
            playerRB.AddForce(new Vector3(5, 0, 0), ForceMode.VelocityChange);

            playerRB.rotation = Quaternion.LookRotation(Vector3.right);
        }

        /*//Move Code with Buttons

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

            //Control.Hinput = LeftJoystick.inputVector.x;
            //Control.Vinput = LeftJoystick.inputVector.y;
        } */
    }
}
