using UnityEngine.UI;
using UnityEngine;
using System.Collections;



public class TurretHealth : MonoBehaviour
{
    //set starting health of turret
    public float curHealth = 100;
    public static bool death;
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

        if (curHealth <= 0)
        {
            Destroy(gameObject);
            GameManager.coins = GameManager.coins + 10;
            GameManager.numofkilled++;

        }

    }

    // https://unity3d.com/learn/tutorials/topics/physics/detecting-collisions-oncollisionenter
    void OnCollisionEnter(Collision col)
    {
        // detect the hit
        Debug.Log("Turret Hit");
        Debug.Log(col.gameObject.tag);
        // the object that has hit it is a bullet
        if (col.gameObject.tag == "BulletEnemy")
        {
            //remove 10 health
            curHealth = curHealth - 10;
            Debug.Log("turret Took Damage from bullet");

        }

    }
}