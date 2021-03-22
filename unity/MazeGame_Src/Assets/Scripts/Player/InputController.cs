using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HeDude;

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
        private RaycastHit hitInfo;

        private GameObject[] doors;
        private GameObject[] puzzleContainers;

        private bool meaningPuzzleIsActive;
        private bool applicationPuzzleIsActive;
        private bool productivePuzzleIsActive;
        private bool reproductivePuzzleIsActive;

        //Store current escape room position
        Matrix3by3 currentPosition;

        //Start is called before the first frame update
        private void Start()
        {
            playerCamera = Camera.main;

            mouseRange = 5;

            uiText = GameObject.Find("UIText").GetComponent<Text>();

            uiText.text = "";

            doors = GameObject.FindGameObjectsWithTag("Door");
            puzzleContainers = GameObject.FindGameObjectsWithTag("PuzzleContainer");

            foreach (GameObject container in puzzleContainers)
                container.SetActive(false);

            meaningPuzzleIsActive = false;
            applicationPuzzleIsActive = false;
            productivePuzzleIsActive = false;
            reproductivePuzzleIsActive = false;
        }

        //Update is called once per frame
        private void Update()
        {
            //Checks whether clicks on a answer button
            CheckAnswerButtonPress();

            //Checks whether a puzzle is currently is active and if it should stop
            CheckToStopPuzzle();
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
                        StartPuzzle(currentPosition, hitInfo.collider.gameObject.name);
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
            {
                foreach (GameObject door in doors)
                    StartCoroutine(OpenAllDoors(door.name, true));

                currentPosition = other.gameObject.GetComponent<Escaperoom>().Position;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            //Checks whether the tag of the collided object is Escape Room
            if (other.tag == "EscapeRoom")
                foreach (GameObject door in doors)
                    CloseDoor(door.name, false);
            
            foreach (GameObject container in puzzleContainers)
                container.SetActive(false);
        }

        private IEnumerator OpenAllDoors(string _type, bool _state)
        {
            yield return new WaitForSeconds(1);
                CloseDoor(_type, _state);
        }

        //Start specific puzzle depending on type
        private void StartPuzzle(Matrix3by3 _position, string _type)
        {
            if (_type == reproductive)
                StartReproductivePuzzle(_position); //tell me how to learn
            if (_type == application)
                StartApplicationPuzzle(_position); //I like to find out how i learn by doing
            if (_type == productive)
                StartProductivePuzzle(_position); //Determine how i learn by myself
            if (_type == meaning)
                StartMeaningPuzzle(_position); //investigate learning
        }

        //Start reproductive puzzle depending on which room you are in
        private void StartReproductivePuzzle(Matrix3by3 _position)
        {
            Debug.Log("REPODRUCTIVE PUZZLE");
            if (_position == Matrix3by3.Center)
            {
                foreach (GameObject puzzleContainer in puzzleContainers)
                    if (puzzleContainer.name == "CenterReproductive")
                        puzzleContainer.SetActive(true);

                reproductivePuzzleIsActive = true;
            }
        }

        //Start meaning puzzle depending on which room you are in
        private void StartMeaningPuzzle(Matrix3by3 _position)
        {
            Debug.Log("MEANING PUZZLE");

            if (_position == Matrix3by3.Center)
            {
                foreach (GameObject puzzleContainer in puzzleContainers)
                    if (puzzleContainer.name == "CenterMeaning")
                        puzzleContainer.SetActive(true);

                meaningPuzzleIsActive = true;
            }
        }

        //Start productive puzzle depending on which room you are in
        private void StartProductivePuzzle(Matrix3by3 _position)
        {
            Debug.Log("PODRUCTIVE PUZZLE");
            if(_position == Matrix3by3.Center)
            {
                foreach (GameObject puzzleContainer in puzzleContainers)
                    if (puzzleContainer.name == "CenterProductive")
                        puzzleContainer.SetActive(true);

                productivePuzzleIsActive = true;
            }
        }

        //Start application puzzle depending on which room you are in
        private void StartApplicationPuzzle(Matrix3by3 _position)
        {
            Debug.Log("APPLICATION PUZZLE");
            if (_position == Matrix3by3.Center)
            {
                foreach (GameObject puzzleContainer in puzzleContainers)
                    if (puzzleContainer.name == "CenterApplication")
                        puzzleContainer.SetActive(true);

                applicationPuzzleIsActive = true;
            }
        }

        //Stops the puzzle
        private void CheckToStopPuzzle()
        {
            if(reproductivePuzzleIsActive)
            {
                //Shoots a raycast from the main character
                Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, mouseRange))
                {
                    if (hitInfo.collider.gameObject.tag == "PuzzleFinish")
                    {
                        uiText.text = "Press 'left mousebutton' to interact";

                        if (Input.GetMouseButtonDown(0))
                        {
                            CloseDoor(reproductive, false);

                            foreach (GameObject puzzleContainer in puzzleContainers)
                                if (puzzleContainer.name == "CenterReproductive")
                                    puzzleContainer.SetActive(false);

                            reproductivePuzzleIsActive = false;
                        }
                    }
                    else
                        uiText.text = "";
                }
                else
                    uiText.text = "";
            }


            if (productivePuzzleIsActive)
            {
                //Shoots a raycast from the main character
                Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, mouseRange))
                {
                    if (hitInfo.collider.gameObject.tag == "PuzzleFinish")
                    {
                        uiText.text = "Press 'left mousebutton' to interact";

                        if (Input.GetMouseButtonDown(0))
                        {
                            CloseDoor(productive, false);

                            foreach (GameObject puzzleContainer in puzzleContainers)
                                if (puzzleContainer.name == "CenterProductive")
                                    puzzleContainer.SetActive(false);

                            productivePuzzleIsActive = false;
                        }
                    }
                    else
                        uiText.text = "";
                }
                else
                    uiText.text = "";
            }


            if (meaningPuzzleIsActive)
            {
                //Shoots a raycast from the main character
                Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, mouseRange))
                {
                    if (hitInfo.collider.gameObject.tag == "PuzzleFinish")
                    {
                        uiText.text = "Press 'left mousebutton' to interact";

                        if (Input.GetMouseButtonDown(0))
                        {
                            CloseDoor(meaning, false);

                            foreach (GameObject puzzleContainer in puzzleContainers)
                                if (puzzleContainer.name == "CenterMeaning")
                                    puzzleContainer.SetActive(false);

                            meaningPuzzleIsActive = false;
                        }
                    }
                    else
                        uiText.text = "";
                }
                else
                    uiText.text = "";
            }

            if (applicationPuzzleIsActive)
            {
                //Shoots a raycast from the main character
                Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, mouseRange))
                {
                    if (hitInfo.collider.gameObject.tag == "PuzzleFinish")
                    {
                        uiText.text = "Press 'left mousebutton' to interact";

                        if (Input.GetMouseButtonDown(0))
                        {
                            CloseDoor(application, false);

                            foreach (GameObject puzzleContainer in puzzleContainers)
                                if (puzzleContainer.name == "CenterApplication")
                                    puzzleContainer.SetActive(false);

                            applicationPuzzleIsActive = false;
                        }
                    }
                    else
                        uiText.text = "";
                }
                else
                    uiText.text = "";
            }
        }
    }
}
