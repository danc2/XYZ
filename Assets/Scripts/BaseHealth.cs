﻿using UnityEngine.UI;
using UnityEngine;
using System.Collections;



public class BaseHealth : MonoBehaviour
{

    public float curHealth = 10000;
	public Slider health;
    public static bool death;
    //public Slider Slider;
    // Use this for initialization


    void Start()
    {
		health.maxValue = curHealth;
		death = false;
    }






    // Update is called once per frame


    void Update()
    {

		health.value =  curHealth;

        if (curHealth <= 0)
        {
            Destroy(gameObject);
			death = true;
            //ADD in code here to take you to loose screen etc
            Debug.Log("YOU LOOSE!!");
            Application.LoadLevel(0);
        }

    }

    // https://unity3d.com/learn/tutorials/topics/physics/detecting-collisions-oncollisionenter
    void OnCollisionEnter(Collision col)
    {
        // detect the hit
        Debug.Log("Hit");
        Debug.Log(col.gameObject.tag);
        // the object that has hit it is a bullet
        if (col.gameObject.tag == "BulletEnemy")
        {
            //remove 10 health
            curHealth = curHealth - 10;
            Debug.Log("Took Damage from bullet");

        }

    }
}