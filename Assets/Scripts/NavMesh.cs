using UnityEngine;
using System.Collections;
using System;

public class NavMesh : MonoBehaviour {

    public Transform target;
    NavMeshAgent agent;
    public bool m_Follow;
    
    void Awake()
    {
        // set the starting state
        m_Follow = false;
        Debug.Log("dont stop");
    }


    // Use this for initialization
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        // if the unit is set to not be attacking, then continue towards the player base
        if (m_Follow == false)
        {
            agent.SetDestination(target.position);
            Debug.Log("Im heading for my target");

        }
        if (m_Follow == true)
        {
           // lastAgentVelocity = agent.velocity;
            //lastAgentPath = agent.path;
            agent.velocity = Vector3.zero;
            agent.ResetPath();


            //agent.Stop();
            //agent.ResetPath();
            Debug.Log("I should stop");
        }
    }



    // these two scripts determine if the enemy unit has entered range of a playerturret 
    // TO DO add in the check for the actual player
    //private void OnTriggerEnter(Collider other)
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PlayerTurret")
        {
            m_Follow = true;
            Debug.Log("Target entered range");
            //agent.Stop();
            //agent.ResetPath();
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
        //if (other.tag == "PlayerTurret")
        //{
        //    m_Follow = false;
        //}
    //}


}
