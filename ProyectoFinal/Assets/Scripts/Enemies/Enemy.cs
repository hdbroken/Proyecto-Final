using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private WaypointsManager _waypointList;

    private NavMeshAgent _navigation;

    private int _index = 0;

    private void Awake()
    {
        _navigation = GetComponent<NavMeshAgent>();        
    }
    // Start is called before the first frame update
    void Start()
    {
        _navigation.SetDestination(_waypointList.waypoint[_index].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (_index < _waypointList.waypoint.Count)
        {
            if (_navigation.remainingDistance == 0)
            {
                if ((_index + 1 < _waypointList.waypoint.Count))
                {
                    _index++;
                    _navigation.SetDestination(_waypointList.waypoint[_index].transform.position);
                }
                else
                {
                    _index = -1;
                }
            }

        }
        else
        {
            _index = -1;
        }
    }
}
