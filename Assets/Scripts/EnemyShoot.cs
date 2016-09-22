using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {
    // prefab of the Shell
    public Rigidbody m_Shell;
    // a child of the tank where the shells are spawned
    public Transform m_FireTransform;

    // the force given to the shell when firing
    public float m_LaunchForce = 30f;

    public float m_ShootDelay = 1f;

    private bool m_CanShoot;
    private float m_ShootTimer;

    // set audio source
    //public AudioSource m_source;

    private void Awake()
    {
        m_CanShoot = false;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (m_CanShoot == true)
        {
            m_ShootTimer -= Time.deltaTime;
            if (m_ShootTimer <= 0)
            {
                m_ShootTimer = m_ShootDelay;
                Debug.Log("Shoot!");
                Fire();
            }
        }
        m_CanShoot = false; // reset canshoot
    }

    private void Fire()
    {
        // create an instance of the shell and store a reference to its rigidbody
        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        // play audio sound when enemy fires
        //m_source.Play();

        // set the shell's velocity to the launch force in the fire positions forward direction
        shellInstance.velocity = m_LaunchForce * m_FireTransform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerTurret")
        {
            Debug.Log("I see a target to shoot");
            m_CanShoot = true;
            m_ShootTimer = m_ShootDelay;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerTurret")
        {
            m_CanShoot = false;
        }
    }

    // added this code to help reset tank on start of new game to stop it starting chasing/shooting player - im sure there is a better way...but this worked for what i needed :-)
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            m_CanShoot = true;
        }
    }

}