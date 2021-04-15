using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Runs when the button has been pressed
    public void PressButton(string _buttonType)
    {
        switch (_buttonType)
        {
            case "play":
                SceneManager.LoadScene("Maze");
                break;
            case "resume":
                gameObject.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Camera.main.gameObject.GetComponent<CameraController>().EnableSensitivity();
                Time.timeScale = 1;
                break;
            case "return":
                SceneManager.LoadScene("MainMenu");
                break;
            case "credits":
                Debug.Log("credits");
                break;
            case "restart":
                SceneManager.LoadScene("Maze");
                Time.timeScale = 1;
                break;
            case "quit":
                Application.Quit();
                Debug.Log("quit");
                break;
            default:
                Debug.Log("nothin");
                break;
        }
    }
}
