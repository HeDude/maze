using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private GameObject player;
    private Camera playerCamera;
    [SerializeField] private float mouseRange;

    //Store raycast information
    RaycastHit hitInfo;

    //Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCamera = Camera.main;

        mouseRange = 5;
    }

    //Update is called once per frame
    private void Update()
    {
        
        //Shoots a raycast from the main character
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, mouseRange))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hitInfo.collider.gameObject.name == "Reproductive")
                    Debug.Log("Reproductive");

                if (hitInfo.collider.gameObject.name == "Application")
                    Debug.Log("Application");

                if (hitInfo.collider.gameObject.name == "Productive")
                    Debug.Log("Productive");

                if (hitInfo.collider.gameObject.name == "Meaning")
                    Debug.Log("Meaning");
            }
        }

    }

    //Returns the object the player is hovering over
    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        //Clears the target
        GameObject target = null;

        //Shoots a raycast from the main character
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, mouseRange))
        {
            if (hit.collider.gameObject.tag == "Button")
            {
                //Set the hit gameobject as the target
                target = hit.collider.gameObject;
            }
        }

        //Return the target
        return target;
    }
}
