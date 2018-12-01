using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    [SerializeField] float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPosition = transform.position;
        newPosition.x += Input.GetAxis("Vertical") * Time.deltaTime * -speed;
        newPosition.z += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        transform.position = newPosition;
	}
}
