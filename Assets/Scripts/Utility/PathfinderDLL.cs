using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class PathfinderDLL : MonoBehaviour
{
    [DllImport("DLL_GEDI")]
    private static extern Vector3 NextPos(Vector3 current, Vector3 target, float step);

    private NavMeshAgent _agent;
    public Transform _target;
    public float _step;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (_target != null)
        {
            Vector3 nextPosition = NextPos(transform.position, _target.position, _step);

            _agent.SetDestination(nextPosition);
        }
    }
}
