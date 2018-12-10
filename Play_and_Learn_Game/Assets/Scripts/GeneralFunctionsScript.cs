using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralFunctionsScript : MonoBehaviour {

    [SerializeField] GameObject sign;
    [SerializeField] float cameraTravelTime = 2f;
    public bool cameraIsMoving = false;
    public bool startCameraMovement = false;
    Camera camera;
    GameObject player;
    GameObject mainMenu;

    [SerializeField] Vector3 initialCameraRotation;
    [SerializeField] Vector3 initialCameraPosition;
    [SerializeField] Vector3 finalCameraRotation;
    [SerializeField] Vector3 finalCameraPosition;
    [SerializeField] Vector3 cameraRotationWhenMenuStart;

    [SerializeField] float endTravelTime;

    private void Awake()
    {
        camera = Camera.main;
        cameraRotationWhenMenuStart = camera.gameObject.transform.rotation.eulerAngles - new Vector3(0, 360, 0);
    }

    private void Update()
    {
        CameraMovement();
    }

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

    public void StartCameraMovement(Camera tempCamera, GameObject tempPlayer, GameObject tempMainMenu)
    {
        if (startCameraMovement)
        {
            camera = tempCamera;
            player = tempPlayer;
            mainMenu = tempMainMenu;
            cameraIsMoving = true;
            var playerScript = player.GetComponent<PlayerScript>();

            camera.gameObject.transform.parent = null;

            initialCameraRotation = cameraRotationWhenMenuStart + tempMainMenu.gameObject.transform.rotation.eulerAngles;
            initialCameraPosition = camera.gameObject.transform.position;
            finalCameraPosition = player.transform.position + playerScript.cameraPositionOnPlayer;
            finalCameraRotation = playerScript.cameraRotationOnPlayer;
            endTravelTime = Time.time + cameraTravelTime;
            startCameraMovement = false;
        }
    }

    private void CameraMovement()
    {
        if (cameraIsMoving)
        {
            var playerScript = player.GetComponent<PlayerScript>();

            if (Time.time <= endTravelTime) {
                float timeFactor = endTravelTime - Time.time;

                Vector3 positionAmount = (finalCameraPosition - initialCameraPosition);
                Vector3 rotationAmount;
                if (cameraRotationWhenMenuStart.y + mainMenu.gameObject.transform.rotation.eulerAngles.y <= playerScript.cameraRotationOnPlayer.y + 180) {
                    rotationAmount = (finalCameraRotation - initialCameraRotation);
                } else
                {
                    rotationAmount = new Vector3 (finalCameraRotation.x - initialCameraRotation.x,
                                                  -(finalCameraRotation.y + initialCameraRotation.y) + 180,
                                                  finalCameraRotation.z - initialCameraRotation.z
                                                  );
                }

                camera.transform.position = finalCameraPosition - positionAmount * (timeFactor / cameraTravelTime);
                if (cameraRotationWhenMenuStart.y + mainMenu.gameObject.transform.rotation.eulerAngles.y <= playerScript.cameraRotationOnPlayer.y + 180)
                {
                    camera.transform.rotation = Quaternion.Euler(initialCameraRotation + rotationAmount * ((cameraTravelTime - timeFactor) / cameraTravelTime));
                } else
                {
                    camera.transform.rotation = Quaternion.Euler(initialCameraRotation + rotationAmount * ((cameraTravelTime - timeFactor) / cameraTravelTime));
                }
            } else
            {
                cameraIsMoving = false;
                camera.gameObject.transform.SetParent(player.gameObject.transform);
                camera.gameObject.transform.position = finalCameraPosition;
                camera.gameObject.transform.rotation = Quaternion.Euler(finalCameraRotation);
            }
        }
    }
}
