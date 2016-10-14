using UnityEngine;
using System.Collections;

public class FPSBullet : MonoBehaviour {

	// Use this for initialization
	public void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Ground") {
			Destroy (gameObject);
		}
		if (col.gameObject.tag == "Enemy") {
			Destroy (col.gameObject);
			Destroy (gameObject);
		}
	}
}
