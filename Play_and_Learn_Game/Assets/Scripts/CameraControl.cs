using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    [SerializeField] GameObject character;

    public float Xoffset;
    public float Zoffset;
    Vector3 cameraInitialPos;
    Vector3 position;

    // Use this for initialization
    void Start()
    {
        Xoffset = character.transform.position.x - transform.position.x;
        Zoffset = character.transform.position.z - transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

        position = new Vector3(character.transform.position.x - Xoffset, transform.position.y, character.transform.position.z - Zoffset);
        transform.position = position;
    }
}
