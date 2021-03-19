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
        }

        private IEnumerator OpenAllDoors(string _type, bool _state)
        {
            yield return new WaitForSeconds(1);
                CloseDoor(_type, _state);
        }

        private void StartPuzzle(Matrix3by3 _position, string _type)
        {
            switch (_position)
            {
                case Matrix3by3.Center:
                    if (_type == reproductive)
                        StartCenterReproductivePuzzle(); //tell me how to learn
                    if (_type == application)
                        StartCenterApplicationPuzzle(); //I like to find out how i learn by doing
                    if (_type == productive)
                        StartCenterProductivePuzzle(); //Determine how i learn by myself
                    if (_type == meaning)
                        StartCenterMeaningPuzzle(); //investigate learning
                    break;
                case Matrix3by3.TopLeft:
                    break;
                case Matrix3by3.Top:
                    break;
                case Matrix3by3.TopRight:
                    break;
                case Matrix3by3.Right:
                    break;
                case Matrix3by3.BottomRight:
                    break;
                case Matrix3by3.Bottom:
                    break;
                case Matrix3by3.BottomLeft:
                    break;
                case Matrix3by3.Left:
                    break;
                default:
                    break;
            }
        }

        private void StartCenterReproductivePuzzle()
        {
            Debug.Log("REPODRUCTIVE PUZZLE");
            CloseDoor(reproductive, false);
        }

        private void StartCenterMeaningPuzzle()
        {
            Debug.Log("MEANING PUZZLE");
            
            foreach (GameObject puzzleContainer in puzzleContainers)
                if (puzzleContainer.name == "CenterMeaning")
                    puzzleContainer.SetActive(true);

            CloseDoor(meaning, false);
        }

        private void StartCenterProductivePuzzle()
        {
            Debug.Log("PODRUCTIVE PUZZLE");
            CloseDoor(productive, false);
        }

        private void StartCenterApplicationPuzzle()
        {
            Debug.Log("APPLICATION PUZZLE");
            CloseDoor(application, false);
        }
    }
}
