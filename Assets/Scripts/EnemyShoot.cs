using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {
    //store current target
    private Transform turretTarget;
    //set turret range
    // TODO change this for each type of enemy******************************
    private float turretRange = 50f;

    // this is the part of the turrent we actually want to rotate
    // need to relook at this when we decide what models we actually want to have
    // note the machine gun for example is a whole model with no moving parts! 
    public Transform partToRotate;
    private float speedToRotate = 10f;

    // this sets up how fast the turret can fire
    //check on Zach code from the tank tutorial
    private float fireRate = 4f;
    private float fireCountdown = 0f;

    //set up object and location for bullet prefab to spawn
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Use this for initialization
    void Start()
    {
        // this sets the rate at which to search for a target
        //idea is from Brackeys to do it every frame like this - Need to learn how this works
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

    }

    // this function finds the nearest target
    // TODO there is probably a more efficent way to do this. ***************
    // maybe look to see if there an enemy in range?
    void UpdateTarget()
    {
        // find all objects that have been tagged as Enemy and place in array
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("PlayerTurret");

        //set variable for shortest distance and the object
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        // loop through all enemies to find closest one
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                // if you find something closer, then set dist and object to new
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

        }
        // this checks that is has an enemy target and also that the target is within the range of the turret
        if (nearestEnemy != null && shortestDistance <= turretRange)
        {
            turretTarget = nearestEnemy.transform;

        }
        else
        {
            // if no target set it back to null
            turretTarget = null;
        }

    }

    // Update is called once per frame
    // ZACH - need to check should this be on fixed update in order to smooth it out?
    void Update()
    {
        // if the turret doesnt have a current target, return with null (to remove target)
        if (turretTarget == null)
            return;

        // determine the angle to look at turret to target\
        // TODO add code to make the turrent turning smoother ***************************************
        // and need to make the correct part of the turrent rotate..not the whole thing - as had to flip the object as model facing wrong way
        Vector3 dir = turretTarget.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * speedToRotate).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        // this is the part that shoots/checks time to shoot
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    // this function shoots the turret
    void Shoot()
    {
        // give the instantiated bullet a name of bulletGO - which lets us reference it from the bullet script.
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(turretTarget);
        }
    }

}
