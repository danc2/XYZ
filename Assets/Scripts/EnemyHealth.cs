using UnityEngine.UI;
using UnityEngine;
using System.Collections;
 


public class EnemyHealth : MonoBehaviour {
	public float maxHealth	= 1000;
	public float curHealth = 100;
	public static bool death;
	public Slider Slider;
   // Use this for initialization


	void Start() {
		Slider.value = maxHealth;

		}



		


 // Update is called once per frame


	 void Update () {

		Slider.value =  curHealth;
	  	
		if (curHealth == 0) {
			death = true;
		}

		   }

	void OnTriggerEnter(Collider col){
		if (col.tag == "Bullet") {
			curHealth = curHealth - 10;

		}
	}
  




		    }


	
