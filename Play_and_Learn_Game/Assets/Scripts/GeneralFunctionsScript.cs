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
            case "Building":
                //create sign using the building object
                CreateSignFromBuilding(recipient);
                break;

            case "Road":
                //create the sign on the point where we hit the map
                CreateSignOnGround(recipient, position);
                break;
            case "Grass":
                //create the sign on the point where we hit the map
                CreateSignOnGround(recipient, position);
                break;
        }
    }

    private void CreateSignFromBuilding(GameObject recipient)
    {
        //TODO adjust this function to position the sign properly
        Debug.Log("Create sign through house");
        var buildingCollider = recipient.GetComponent<BoxCollider>();

        Vector3 signPosition = new Vector3(
            recipient.gameObject.transform.position.x,
            buildingCollider.center.y + buildingCollider.size.y / 2,
            buildingCollider.gameObject.transform.position.z
        );

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

    public void CameraMoveToPlayer(Camera camera, GameObject player)
    {
        camera.gameObject.transform.SetParent(player.gameObject.transform);
        var playerScript = player.GetComponent<PlayerScript>();
        camera.transform.position = player.transform.position + playerScript.cameraPositionOnPlayer;
        camera.transform.rotation = Quaternion.Euler(playerScript.cameraRotationOnPlayer);
    }
}
