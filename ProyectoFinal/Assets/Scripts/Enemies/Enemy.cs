using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : EnemyBase
{
    [SerializeField]
    private WaypointsManager _waypointList;

    private GameObject _target;    
    private NavMeshAgent _navigation;
    private int _index = 0;
    private Animator _enemyAnimator;

    private void Awake()
    {
        _navigation = GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectWithTag("Player");        
        _enemyAnimator = GetComponentInChildren<Animator>();
    }
    
    void Start()
    {
        Move();
    }

    void Update()
    {
        MoveToNextPoint();
    }

    private void MoveToNextPoint()
    {
        if (!IsInLOS(_target))
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
        else if (IsInLOS(_target))
        {
            _navigation.isStopped = true;
            if(_enemyAnimator != null) _enemyAnimator.SetBool("isWalk", false);
            LookPlayer();
            if (IsInShootingRange(_target))
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

        Quaternion targetRotation = Quaternion.LookRotation(_target.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _fov.speedToRotation);
    }
}
