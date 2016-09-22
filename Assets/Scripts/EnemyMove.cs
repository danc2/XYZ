using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;

    //this is the base object we are tracking to
    private GameObject playerBase;
    // set variable to check distance
    public float m_CloseDistance = 50f;

    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
    }
    void Update()
    {

        // get distance from player to enemy tank
        float distance = (target.transform.position - transform.position).magnitude;
        

        // if distance is less than stop distance, then stop moving
        if (distance > m_CloseDistance)
        {
            agent.SetDestination(target.transform.position);
            agent.Resume();
            Debug.Log(distance);
        }
        else
        {
            agent.Stop();
            Debug.Log("I should stop moving!");
        }


    }

}
