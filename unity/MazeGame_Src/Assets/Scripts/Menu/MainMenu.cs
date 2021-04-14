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
            case "credits":
                Debug.Log("start");
                break;
            case "quit":
                Application.Quit();
                break;
            default:
                Debug.Log("nothin");
                break;
        }
    }
}
