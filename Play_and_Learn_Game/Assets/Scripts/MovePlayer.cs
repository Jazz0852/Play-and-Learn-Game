using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour    {

    Animator animLiam;
    float speed = 10.0f;

    void Start()
    {
        animLiam = GetComponent<Animator>();
    }

    void Update()
    {

        //walkLiam
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //animate walk
            animLiam.SetTrigger("Walk");           
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //move player
            transform.position += Vector3.forward * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //move player
            transform.position += Vector3.left * Time.deltaTime * speed;
        }

        //StopLiam
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.LeftArrow)) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animLiam.SetTrigger("Stop");
        }
    }
}