using UnityEngine.UI;
using UnityEngine;
using System.Collections;



public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 1000;
    public float curHealth = 100;
    public static bool death;
    // daniel can you put this back in - I couldnt find the asset for the tank
    //public Slider Slider;
    // Use this for initialization


    void Start()
    {
        //Slider.value = maxHealth;

    }






    // Update is called once per frame


    void Update()
    {

        //Slider.value =  curHealth;

        if (curHealth < 0)
        {
            Destroy(gameObject);

        }

    }
    // https://unity3d.com/learn/tutorials/topics/physics/detecting-collisions-oncollisionenter
    void OnCollisionEnter(Collision col)
    {
        // detect the hit
        Debug.Log("Hit");
        Debug.Log(col.gameObject.tag);
        // the object that has hit it is a bullet
        if (col.gameObject.tag == "Bullet")
        {
            //remove 10 health
            curHealth = curHealth - 10;
            Debug.Log("Took Damage from bullet");

        }
        // the object that has hit it is a missile
        if (col.gameObject.tag == "Missile")
        {
            //remove 10 health
            curHealth = curHealth - 50;
            Debug.Log("Took Damage from missile");

        }
    }
}