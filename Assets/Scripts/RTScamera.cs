using UnityEngine;
using System.Collections;


public class RTScamera : MonoBehaviour {
	public int scrollDistance = 1; 
	public float CameraSpeed = 70;
	public float zoomspeed = 2;
	public float rotateAngle = 45;
	public float distance = 20;
	public float sensitivityDistance = 20;
	public float damping = 5;
	public float minFOV = 10;
	public float maxFOV = 30;

	// Use this for initialization
	void Start () {
		Camera.main.fieldOfView = distance;
	}
	// Update is called once per framesa
	void Update () {

		float mousePosX = Input.mousePosition.x; 
		float mousePosY = Input.mousePosition.y; 


		if (mousePosX < scrollDistance || Input.GetKey(KeyCode.A)) 
			           { 

			transform.Translate(Vector3.left * CameraSpeed * Time.deltaTime);
		} 

		if (mousePosX >= Screen.width - scrollDistance || Input.GetKey(KeyCode.D)) 
			         { 
			transform.Translate(Vector3.right * CameraSpeed * Time.deltaTime);
		}

		if (mousePosY < scrollDistance || Input.GetKey(KeyCode.S)) 
			           { 
			transform.Translate(Vector3.down * CameraSpeed * Time.deltaTime);
		} 

		if (mousePosY >= Screen.height - scrollDistance || Input.GetKey(KeyCode.W))
		           { 
			transform.Translate(Vector3.up * CameraSpeed * Time.deltaTime);
		}

		distance -= Input.GetAxis("Mouse ScrollWheel") * sensitivityDistance;
		distance = Mathf.Clamp(distance, minFOV, maxFOV);
		Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, distance, Time.deltaTime * damping);
		if (Input.GetKey (KeyCode.Q)) {
			transform.Rotate(Vector3.forward, -rotateAngle * Time.deltaTime);

		}
		if (Input.GetKey (KeyCode.E)) {
			transform.Rotate(Vector3.forward, rotateAngle * Time.deltaTime);

		}


}

}
