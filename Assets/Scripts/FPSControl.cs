﻿using UnityEngine.Audio;
using System.Collections;
using UnityEngine;

public class FPSControl : MonoBehaviour {
	//static bool for weapons equip
	public static bool HandGun;
	public static bool Assault;
	public static bool ShotGun;

	public Animator animator;
	public float WalkSpeed = 10;
	// Use this for initialization
	void Start () {
		animator.GetComponent<Animator> ();
		animator.SetFloat ("Body_Horizontal_f", 0);


	}
	
	// Update is called once per frame
	void Update () {
	
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");
		animator.SetFloat ("Speed_f", v);

		if (v == 1) {
			animator.SetFloat ("Speed_f", 1);
			transform.Translate (Vector3.forward * WalkSpeed * Time.deltaTime);
		} else if (v == -1) {
			transform.Translate (Vector3.back * WalkSpeed * Time.deltaTime);
			animator.SetFloat ("Speed_f", 1);
		}
		if (Input.GetKey (KeyCode.Alpha1)) {
			animator.SetInteger ("WeaponType_int", 1);
			animator.SetFloat ("Body_Horizontal_f", 0);
			HandGun = true;
			Assault = false;
			ShotGun = false;
		} else if (Input.GetKey (KeyCode.Alpha2)) {
			animator.SetFloat ("Body_Horizontal_f", 0.59f);
			animator.SetInteger ("WeaponType_int", 3);
			Assault = true;
			HandGun = false;
			ShotGun = false;
		} else if (Input.GetKey (KeyCode.Alpha3)) {
			ShotGun = true;
			HandGun = false;
			Assault = false;
			animator.SetInteger ("WeaponType_int", 4);
		}
		if (h == 1) {
			transform.Translate (Vector3.right * WalkSpeed * Time.deltaTime);
		} else if (h == -1) {
			transform.Translate (Vector3.left * WalkSpeed * Time.deltaTime);

		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			transform.Translate (Vector3.up * WalkSpeed * Time.deltaTime);

		}
	
		if (Input.GetButtonDown ("Fire1")) {
			animator.SetBool ("Shoot_b", true);

		}
		else animator.SetBool ("Shoot_b", false);
	}
	}
	
