using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

    [SerializeField] GameObject loginMenu;
    [SerializeField] GameObject teamMenu;
    [SerializeField] GameObject presentYourselfMenu;
    [SerializeField] GameObject ambitionMenu;
    [SerializeField] GameObject startMenu;

    float rotationVariable = 0;
    [SerializeField] Camera camera;
    [SerializeField] GameObject player;
    [SerializeField] float cameraRotationSpeed = 0.5f;
    MeshRenderer playerMesh;
    private void Start()
    {
        camera = Camera.FindObjectOfType<Camera>();
        player = GameObject.Find("Player");
        playerMesh = player.gameObject.GetComponentInChildren<MeshRenderer>();
        playerMesh.gameObject.SetActive(false);
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
        playerMesh.gameObject.SetActive(true);
    }

    private void StartCameraMovement()
    {
        var generalFunctions = GameObject.Find("General Functions");
        var generalFunctionsScript = generalFunctions.GetComponent<GeneralFunctionsScript>();
        generalFunctionsScript.startCameraMovement = true;
        generalFunctionsScript.StartCameraMovement(camera, player, gameObject);
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

    void SetMenusUnActive()
    {
        loginMenu.gameObject.SetActive(false);
        teamMenu.gameObject.SetActive(false);
        presentYourselfMenu.gameObject.SetActive(false);
        ambitionMenu.gameObject.SetActive(false);
        startMenu.gameObject.SetActive(false);
    }

    public void GoToLoginMenu()
    {
        SetMenusUnActive();
        loginMenu.gameObject.SetActive(true);
    }

    public void GoToTeamMenu()
    {
        SetMenusUnActive();
        teamMenu.gameObject.SetActive(true);
    }

    public void GoToPresentYourselfMenu()
    {
        SetMenusUnActive();
        presentYourselfMenu.gameObject.SetActive(true);
    }

    public void GoToAmbitionMenu()
    {
        SetMenusUnActive();
        ambitionMenu.gameObject.SetActive(true);
    }

    public void GoToStartMenu()
    {
        SetMenusUnActive();
        startMenu.gameObject.SetActive(true);
    }
}
