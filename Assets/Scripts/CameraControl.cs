using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	public bool FPSon;
	public bool RTSon;
	public GameObject FPS;
	public GameObject RTS;
	// Use this for initialization
	void Start () {
		RTSon = true;
		FPSon = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.F)) {
			if (RTSon == true) {
				FPSon = true;
				RTSon = false;
				FPS.SetActive (true);
				RTS.SetActive (false);
				Cursor.visible = false;
		}
			else if (FPSon == true) {
				FPSon = false;
				RTSon = true;
				FPS.SetActive (false);
				RTS.SetActive (true);
				Cursor.visible = true;


			}

			}
	}
}