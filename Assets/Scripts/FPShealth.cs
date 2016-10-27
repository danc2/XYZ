using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FPShealth : MonoBehaviour {
	public Slider HealthSlider;
	public int health = 1000;
	public static bool death;
	// Use this for initialization
	void Start () {
		HealthSlider.maxValue = health;

	}
	
	// Update is called once per frame
	void Update () {
		HealthSlider.value = health;
		if(health ==0)
			death = true;
		
	}

	void OnCollisionEnter(Collision col)
	{

		// the object that has hit it is a bullet
		if (col.gameObject.tag == "BulletEnemy")
		{
			//remove 10 health
			health = health - 10;

		}
}

}
