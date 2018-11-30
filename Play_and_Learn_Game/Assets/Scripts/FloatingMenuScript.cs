using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMenuScript : MonoBehaviour {

    GameObject generalFunctions;
    GeneralFunctionsScript generalFunctionsScript;
    public GameObject recipient;
    public Vector3 pointOnScreen;
    public Vector3 pointOnWorld;

    private void Start()
    {
        generalFunctions = GameObject.Find("General Functions");
        generalFunctionsScript = generalFunctions.GetComponent<GeneralFunctionsScript>();

        CheckButtons();
    }

    private void CheckButtons()
    {
        //this is supposed to check which buttons should be displayed besed on
        //whether the recipient is a sign or not
        //if there is info or not
    }

    public void CallInfoText()
    {
        //create function which calls an info text on the screen
        Debug.Log("show the info related to this place");
        Destroy(gameObject);
    }

    public void CallSignCreation()
    {
        generalFunctionsScript.CreateSign(recipient, pointOnWorld);
        Destroy(gameObject);
    }

    public void CallDeleteSign()
    {
        generalFunctionsScript.DeleteSign(recipient);
        Destroy(gameObject);
    }
}
