using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject target;
    private Vector3 rndPos;
    private NavMeshAgent agent;

    private bool shouldChase;
    private bool commanded;

    private Vector3 lastPos;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
        if (Vector3.Distance(lastPos, target.transform.position) > 1f)
        {
            lastPos = target.transform.position;
            agent.destination = lastPos;
        }
        
        Debug.Log("Seeking Player");
        agent.stoppingDistance = 2f;
        agent.speed = 3f;
        agent.autoBraking = false;
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
        Vector3 spawnPoint = SpawnPosManager.Instance.GetPosition();
        rndPos = new Vector3(Random.Range(spawnPoint.x - 15, spawnPoint.x + 15f), 0, Random.Range(spawnPoint.z - 15, spawnPoint.z + 15f));
    }
    void OnTriggerEnter(Collider other)
    { 
        shouldChase = true;
    }
}
