using UnityEngine;
//using System.Collections;

public class Bullet : MonoBehaviour
{

    private Transform target;

    // set speed of bullet
    public float speed = 70f;

    // set lifetime of bullet
    private float lifetime = 1f;

    public void Seek(Transform _target)
    {
        target = _target;
    }



    // Use this for initialization
    void Start()
    {
        // had to add code here that if the bullet is over X seconds old, it is destroyed to get rid of the floaty bullet problem
        // http://answers.unity3d.com/questions/610673/how-to-destory-a-gameobject-in-c-after-3-seconds.html

        Destroy(gameObject, lifetime);

    }

    // Update is called once per frame
    void Update()
    {
        // if for some reason we loose the target, then destroy the bullet
        if (target == null)
        {
            Destroy(gameObject, 3);
            return;
        }



        // distance to target
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        // this makes the bullet orientate towards the target
        transform.LookAt(target);
    }

    void HitTarget()
    {
        // we hit the target so destroy the bullet
        Destroy(gameObject);
        // need to add in particle system

        // destroy the target after one hit
        // need to be adding in health manager
        // health manager is on a different script
        // code below was used in testing to just destroy the object if it was hit. 
        //Destroy(target.gameObject);

    }


}
