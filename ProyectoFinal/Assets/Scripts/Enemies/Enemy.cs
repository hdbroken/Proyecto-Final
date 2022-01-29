using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private WaypointsManager _waypointList;

    private NavMeshAgent _navigation;

    // Start is called before the first frame update
    void Start()
    {
        _navigation = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _navigation.SetDestination(_waypointList.waypoint[0].transform.position);
        _navigation.SetDestination(_waypointList.waypoint[1].transform.position);
        _navigation.SetDestination(_waypointList.waypoint[2].transform.position);
    }
}
