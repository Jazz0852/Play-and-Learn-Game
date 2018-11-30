using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralFunctionsScript : MonoBehaviour {

    [SerializeField] GameObject sign;

    public void CreateSign(GameObject recipient, Vector3 position)
    {
        //select actions based on the object we point at
        switch (recipient.gameObject.tag)
        {
            case "Buildings":
                //create sign using the building object
                CreateSignFromBuilding(recipient);
                break;

            case "Ground":
                //create the sign on the point where we hit the map
                CreateSignOnGround(recipient, position);
                break;
        }
    }

    private void CreateSignFromBuilding(GameObject recipient)
    {
        //TODO adjust this function to position the sign properly
        Debug.Log("Create sign through house");
        Vector3 signPosition = recipient.gameObject.transform.position;
        signPosition.y += recipient.gameObject.transform.localScale.y / 2;
        var signClone = Instantiate(sign, signPosition, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
    }

    private void CreateSignOnGround(GameObject recipient, Vector3 position)
    {
        //TODO adjust this function to position the sign properly
        Debug.Log("Create sign on the ground");
        var signClone = Instantiate(sign, position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
    }

    public void DeleteSign(GameObject sign)
    {
        if (sign != null)
        {
            Destroy(sign);
        }
    }
}
