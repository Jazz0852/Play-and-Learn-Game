using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManagerScript : MonoBehaviour {

    //the menu we will use each time we click to add or delete something
    [SerializeField] GameObject floatingMenu;
    public Canvas canvas;

    //variables bsed on player
    public float playerClickRange = 3f;
    [SerializeField] GameObject player;

    //create a mask of the things we want to be able to hit with raycasting
    public LayerMask touchInputMask;
    Camera camera;
    GeneralFunctionsScript generalFunctionsScript;
    

    private void Start()
    {
        camera = GetComponent<Camera>();
        var generalObject = GameObject.Find("General Functions");
        generalFunctionsScript = generalObject.GetComponent<GeneralFunctionsScript>();

        //Find the Canvas
        var UIObject = GameObject.Find("InGame UI");

        //Find the player
        player = GameObject.Find("Player");
    }

    private void Update()
    {
#if UNITY_EDITOR
        ApplyMouseRaycast();
#endif
        //TODO change this
        //ApplyFingerRaycast();
    }

    private void ApplyMouseRaycast()
    {
        //create a ray from the camera towards the position of the mouse
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //shoot the ray and if it hits something which is in the touchInputMask we apply the if statement
        if (Physics.Raycast(ray, out hit, touchInputMask))
        {
            //take the gameObject we hit
            GameObject hitObject = hit.transform.gameObject;

            //if the mouse is pressed
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                //click consequences
                Vector3 mouseOnScreenPosition = ReturnMousePos(ref hit, hitObject);
                Vector3 mouseOnWorldPosition = hit.point;
                //check if the click is in range for the player
                if (Vector3.Distance(hit.point, player.gameObject.transform.position) <= playerClickRange)
                {
                    CallFloatingMenu(hitObject, mouseOnScreenPosition, mouseOnWorldPosition);
                }
            }
        }
    }

    private Vector3 ReturnMousePos(ref RaycastHit hit, GameObject hitObject)
    {
        Vector3 mouseOnScreenPosition;

        if (hitObject.gameObject.tag == "Building")
        {
            mouseOnScreenPosition = camera.WorldToScreenPoint(hitObject.transform.position);
        }
        else
        {
            mouseOnScreenPosition = camera.WorldToScreenPoint(hit.point);
        }

        return mouseOnScreenPosition;
    }

    private void ApplyFingerRaycast()
    {
        //TODO fill in this function for finger input

        //this has to be used to avoid going through the UI if we use smartphone input
        //EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)
    }

    private void CallFloatingMenu(GameObject recipient, Vector3 pointOnScreen, Vector3 pointOnWorld)
    {
        //instantiate the floating menu
        var menuClone = Instantiate(floatingMenu, pointOnScreen, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;

        //place the menu in the canvas
        menuClone.transform.SetParent(canvas.transform);

        //pass the information to the menu
        var floatingMenuScript = menuClone.GetComponent<FloatingMenuScript>();
        floatingMenuScript.recipient = recipient;
        floatingMenuScript.pointOnScreen = pointOnScreen;
        floatingMenuScript.pointOnWorld = pointOnWorld;
    }
}
