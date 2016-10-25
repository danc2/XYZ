using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class k : MonoBehaviour {
	public Image bar;
	 public float health = 1;
	public float curhealth;

	// Use this for initialization
	void Start () {
		curhealth = health;
		InvokeRepeating ("decrease", 0f, 2f);
	}

	void decrease(){
		curhealth -= 0.10f;
	}
	// Update is called once per frame
	void Update () {
		bar.fillAmount = curhealth;
		}
	}

