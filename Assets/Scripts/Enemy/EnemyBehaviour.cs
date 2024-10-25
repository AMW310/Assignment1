using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject target;
    public Vector3 rndPos;
    private NavMeshAgent agent;
    private Rigidbody rb;

    private bool shouldChase;
    private bool commanded;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        InvokeRepeating(nameof(WanderDestination), 1f, 5f);
    }

    void OnEnable()
    {
        Detection.PlayerDetected += Chase;
    }

    void OnDisable()
    {
        Detection.PlayerDetected -= Chase;
    }

    void Chase(GameObject obj)
    {
        target = obj;
        if (shouldChase && !commanded)
        {
            //Debug.Log("Wandering");
            agent.speed = 1f;
            agent.isStopped = false;
            agent.destination = rndPos;
        }
    }

    public void Seek()
    {
        commanded = true;
        //Debug.Log("Seeking Player");
        agent.stoppingDistance = 2f;
        agent.speed = 3f;
        agent.destination = target.transform.position;
        agent.isStopped = false;
    }

    public void Flee()
    {
        commanded = true;
        //Debug.Log("Fleeing Player");

        Vector3 destination = transform.position + ((transform.position - target.transform.position) * 1);
        agent.destination = destination;
        agent.speed = 3f;
        agent.isStopped = false;
    }

    public void Wander()
    {
        commanded = true;
        //Debug.Log("Wandering");
        //InvokeRepeating(nameof(WanderDestination), 2f, 10f);
        agent.speed = 1f;
        agent.isStopped = false;
        agent.destination = rndPos;
    }
    void WanderDestination()
    {
        rndPos = new Vector3(Random.Range(-20.0f, 20.0f), 0, Random.Range(0.0f, 40.0f));
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ZoneDetection")
        {
            //Debug.Log("1");
            shouldChase = true;
        }
    }
}
