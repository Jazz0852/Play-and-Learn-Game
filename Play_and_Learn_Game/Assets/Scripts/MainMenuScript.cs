using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

    float rotationVariable = 0;
    [SerializeField] Camera camera;
    [SerializeField] GameObject player;
    [SerializeField] float cameraRotationSpeed = 0.5f;

    private void Start()
    {
        camera = Camera.FindObjectOfType<Camera>();
        player = GameObject.Find("Player");
        player.gameObject.SetActive(false);
        camera.gameObject.transform.SetParent(this.transform);
    }

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        //this function makes the camera turn while the main menu is active
        rotationVariable += cameraRotationSpeed;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, rotationVariable, 0));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LaunchGame()
    {
        SetActiveThePlayer();
        StartCameraMovement();
        EnablePlayer();
        DisableMainMenu();
    }

    private void SetActiveThePlayer()
    {
        player.gameObject.SetActive(true);
    }

    private void StartCameraMovement()
    {
        var generalFunctions = GameObject.Find("General Functions");
        var generalFunctionsScript = generalFunctions.GetComponent<GeneralFunctionsScript>();
        generalFunctionsScript.CameraMoveToPlayer(camera, player);
    }

    private void EnablePlayer()
    {
        var playerScript = player.GetComponent<PlayerScript>();
        playerScript.playerCanMove = true;
        var inputManagerScript = camera.gameObject.GetComponent<InputManagerScript>();
        inputManagerScript.player = player;
    }

    private void DisableMainMenu()
    {
        gameObject.SetActive(false);
        var inputManagerScript = camera.gameObject.GetComponent<InputManagerScript>();
        inputManagerScript.mainMenuIsActive = false;
    }

}
