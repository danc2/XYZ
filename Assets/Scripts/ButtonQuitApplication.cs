using UnityEngine;
using System.Collections;
public class ButtonQuitApplication : MonoBehaviour
{
    //Script to quit game when QUIT button pressed

    public void OnButtonQuit()
    {
        Application.Quit();
    }
}