using UnityEngine;
using System.Collections;
public class ButtonLoadScene : MonoBehaviour
{
    //script for opening game when PLAY button pressed
    public string _MainGame3 = string.Empty;
    public void OnButtonPressed()
    {
        Application.LoadLevel(_MainGame3);
    }
} 