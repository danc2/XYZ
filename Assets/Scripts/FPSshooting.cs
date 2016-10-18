using UnityEngine.Audio;
using UnityEngine;
using System.Collections;

public class FPSshooting : MonoBehaviour {
	
	public Rigidbody m_Shell; 
	public Transform m_FireTransform; 
	public float m_LaunchForce = 30f;
	public AudioClip[] sounds;
	public AudioSource audio;
	public static int clips = 2; // how many clips you have
	public int bulletsPerClip = 20; // how many bullets per clip
	public float reloadTime = 0.5f; // reload time in seconds
	public static float bullets; 

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		bullets = bulletsPerClip;
	}

	// Update is called once per frame 
	private void Update() { 
		if (bullets > 0) { 
			if (Input.GetButtonUp ("Fire1")) {
				Fire ();
				bullets--;
			}
		} else if (clips > 0) { // and still have ammo clips...
			Reload (); // start reload routine
		} else if (clips == 0) {
			audio.clip = sounds[2];
			audio.Play ();
		}
		else if (bullets == 0) {

	}

	}

	private void Fire() { 
		Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
		shellInstance.velocity = m_LaunchForce * m_FireTransform.right; 
		audio.clip = sounds[0];
		audio.Play ();
	}

	private static bool reloading = false; // is true while reloading, false otherwise

	public void Reload(){
		// abort other Reload calls if already reloading:


		clips -= 1; // got one clip, decrement clip count:
		audio.clip = sounds[1];
		audio.Play ();

		bullets = bulletsPerClip; // now the bullets are available


	}

}





