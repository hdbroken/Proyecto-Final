using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsManager : MonoBehaviour
{
    [SerializeField]
    private List<Waypoint> _waypoint;

    public List<Waypoint> waypoint
    {
        get { return _waypoint; }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
