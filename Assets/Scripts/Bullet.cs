using UnityEngine;
//using System.Collections;

public class Bullet : MonoBehaviour {

    private Transform target;

    // set speed of bullet
    public float speed = 70f;

    public void Seek (Transform _target)
    {
        target = _target;
    }



	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        // if for some reason we loose the target, then destroy the bullet
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // distance to target
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        // we hit the target so destroy the bullet
        Destroy(gameObject);
        // need to add in particle system

    }


}
