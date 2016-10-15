using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    // have changed this to private due to moving to prefab instatiate
    Transform target;
    NavMeshAgent agent;
	public Animator anim;
    //this is the base object we are tracking to
    private GameObject playerBase;
    // set variable to check distance
    public float m_CloseDistance = 50f;

    void Start()
    {
        //need to set target for navmesh as we have come from a prefab
        target = GameObject.FindWithTag("HomeBaseTarget").transform;
		anim = GetComponent<Animator> ();
        // set up the navmesh to target the homebase
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
    }
    void Update()
    {

        // get distance from player to enemy tank
        float distance = (target.transform.position - transform.position).magnitude;
        

        // if distance is less than stop distance, then stop moving
        if (distance < m_CloseDistance)
            agent.Stop();
            //Debug.Log("I should stop moving!");

    }

}
