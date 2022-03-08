using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private WaypointsManager _waypointList;

    private GameObject _objective;
    private FieldOfView _player;
    private NavMeshAgent _navigation;
    private int _index = 0;
    private Animator _enemyAnimator;

    private void Awake()
    {
        _navigation = GetComponent<NavMeshAgent>();
        _objective = GameObject.FindGameObjectWithTag("Player");
        _player = GetComponent<FieldOfView>();
        _enemyAnimator = GetComponentInChildren<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Move();

    }

    // Update is called once per frame
    void Update()
    {

        /*if (_player.IsInLOS())
        {
            _navigation.isStopped = true;
            LookPlayer();
        }*/
        MoveToNextPoint();

    }

    private void MoveToNextPoint()
    {
        if (!_player.IsInLOS())
        {
            _navigation.isStopped = false;
            if (_enemyAnimator != null) _enemyAnimator.SetBool("isWalk", true);
            if (_index < _waypointList.waypoint.Count)
            {
                if (_navigation.remainingDistance <= 0)
                {
                    if ((_index + 1 < _waypointList.waypoint.Count))
                    {
                        _index++;
                        Move();
                    }
                    else
                    {
                        _index = 0;
                        Move();
                    }
                }
            }
            else
            {
                _index = 0;
                Move();
            }
        }
        else if (_player.IsInLOS())
        {
            _navigation.isStopped = true;
            if(_enemyAnimator != null) _enemyAnimator.SetBool("isWalk", false);
            LookPlayer();
            if (_player.IsInShootingRange())
            {
                ShootPlayer();
            }
        }
    }

    private void ShootPlayer()
    {
        Debug.Log("Estas Muerto");
    }

    private void Move()
    {

        _navigation.SetDestination(_waypointList.waypoint[_index].transform.position);
    }

    private void LookPlayer()
    {

        Quaternion targetRotation = Quaternion.LookRotation(_objective.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
    }
}
