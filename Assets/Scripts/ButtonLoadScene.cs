using UnityEngine;
using System.Collections;
public class ButtonLoadScene : MonoBehaviour
{
    //script for opening game when PLAY button pressed
    public string _MainGame3 = string.Empty;
	public GameObject info;
	public GameObject menu;
    public void OnButtonPressed()
    {
        Application.LoadLevel(_MainGame3);
    }

	public void infomenu(){
		info.SetActive (true);
		menu.SetActive (false);
	}

	public void returntomenu(){
		info.SetActive (false);
		menu.SetActive (true);
	}
	public void OnButtonQuit()
	{
		Application.Quit();
	}

} 