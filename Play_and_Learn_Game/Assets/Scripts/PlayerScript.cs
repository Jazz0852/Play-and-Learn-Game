using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    [SerializeField] float speed;
    public bool playerCanMove = false;

    public Vector3 cameraPositionOnPlayer;
    public Vector3 cameraRotationOnPlayer;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (playerCanMove)
        {
            Vector3 newPosition = transform.position;
            newPosition.x += Input.GetAxis("Vertical") * Time.deltaTime * -speed;
            newPosition.z += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            transform.position = newPosition;
        }
    }
}
