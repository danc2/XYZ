using UnityEngine;
using System.Collections;

public class FPSControl : MonoBehaviour {

	public Animator animator;
	public float WalkSpeed = 10;
	// Use this for initialization
	void Start () {
		animator.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		float v = Input.GetAxis ("Vertical");
		animator.SetFloat ("Speed_f", v);

		if (v == 1) {
			transform.Translate (Vector3.forward * WalkSpeed * Time.deltaTime);
		} else if (v == -1) {
			transform.Translate (Vector3.back * WalkSpeed * Time.deltaTime);
			animator.SetFloat ("Speed_f", 1);
		}
	}

}
