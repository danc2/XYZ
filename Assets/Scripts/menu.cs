﻿using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class menu : MonoBehaviour {
	public GameObject Menu;
	public GameObject Settings;

	public bool ispause;
	// Use this for initialization
	void Start () {
		ispause = false;
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.Escape)) {
			ispause = !ispause;
			if (ispause) {
				Cursor.visible = true;
				pause ();
			} else {
				unpause ();
			}

		}
	}
	public void pause(){
		Menu.SetActive (true);
		GameManager.pause = true;
		Cursor.visible = true;


}
	public void unpause(){
		Menu.SetActive (false);
		Settings.SetActive(false);
		GameManager.pause = false;
		ispause = false;
		if (GameManager.RTSon == true)
			Cursor.visible = true;
		else if (GameManager.FPSon == true)
			Cursor.visible = false;

	}
	public void Setting(){
		Menu.SetActive (false);
		Settings.SetActive(true);
		GameManager.pause = true;
		ispause = true;
	}

	public void Quit()
	{
		Application.Quit();
	}
	public void backmenu()
	{
		Application.LoadLevel(0);
	}
	public void reset()
	{
		Application.LoadLevel(1);
	}
}
