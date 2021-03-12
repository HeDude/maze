using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Maze
{
    public class InputController : MonoBehaviour
    {
        private Camera playerCamera;
        [SerializeField] private float mouseRange;

        private string reproductive = "Reproductive";
        private string application = "Application";
        private string productive = "Productive";
        private string meaning = "Meaning";

        private Text uiText;

        //Store raycast information
        RaycastHit hitInfo;

        GameObject[] doors;

        //Start is called before the first frame update
        private void Start()
        {
            playerCamera = Camera.main;

            mouseRange = 5;

            uiText = GameObject.Find("UIText").GetComponent<Text>();

            uiText.text = "";

            doors = GameObject.FindGameObjectsWithTag("Door");
        }

        //Update is called once per frame
        private void Update()
        {
            //Checks whether clicks on a answer button
            CheckAnswerButtonPress();
        }

        //Checks whether clicks on a answer button
        private void CheckAnswerButtonPress()
        {
            //Shoots a raycast from the main character
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, mouseRange))
            {
                if (hitInfo.collider.gameObject.tag == "Button")
                {
                    uiText.text = "Press 'left mousebutton' to interact";

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (hitInfo.collider.gameObject.name == reproductive)
                            CloseDoor(reproductive, false);

                        if (hitInfo.collider.gameObject.name == application)
                            CloseDoor(application, false);

                        if (hitInfo.collider.gameObject.name == productive)
                            CloseDoor(productive, false);

                        if (hitInfo.collider.gameObject.name == meaning)
                            CloseDoor(meaning, false);
                    }
                }
                else
                    uiText.text = "";
            }
            else
                uiText.text = "";
        }

        //Closes or opens specific door depending on state
        private void CloseDoor(string _type, bool _state)
        {
            foreach (GameObject door in doors)
                if (door.name == _type)
                    door.SetActive(_state);
        }

        //Checks for collision for a trigger collider
        private void OnTriggerEnter(Collider other)
        {
            //Checks whether the tag of the collided object is Escape Room
            if (other.tag == "EscapeRoom")
                foreach (GameObject door in doors)
                    StartCoroutine(OpenAllDoors(door.name, true));
        }

        private void OnTriggerExit(Collider other)
        {
            //Checks whether the tag of the collided object is Escape Room
            if (other.tag == "EscapeRoom")
                foreach (GameObject door in doors)
                    CloseDoor(door.name, false);
        }

        private IEnumerator OpenAllDoors(string _type, bool _state)
        {
            yield return new WaitForSeconds(1);
                CloseDoor(_type, _state);
        }
    }
}
