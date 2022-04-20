using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : EnemyBase
{
    [SerializeField]
    private Vector3 _offsetSightEnemy = new Vector3(0f, -1.2f, 0f);

    [SerializeField]
    private GameObject _firePoint;

    [SerializeField]
    private GameObject _laserBullet;

    [SerializeField]
    private WaypointsManager _waypointList;

    private GameObject _target;
    private NavMeshAgent _navigation;
    private int _index = 0;
    private Animator _enemyAnimator;
    private bool _canShoot = true;

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
        if (GameManager.instance.playerIsAlive)
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
                if (_enemyAnimator != null) _enemyAnimator.SetBool("isWalk", false);
                LookPlayer();
                if (IsInShootingRange(_target)&&(_canShoot))
                {
                    _canShoot = false;
                    Shoot();
                }
            }
        }
    }
    IEnumerator TimeToNextShoot()
    {
        yield return new WaitForSeconds(_fov.timeBetweenShoots);
        _canShoot = true;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(_laserBullet, _firePoint.transform.position, transform.rotation);
        LaserBullet laser = bullet.GetComponentInChildren<LaserBullet>();
        laser.DirectionToShoot((_target.transform.position - (_firePoint.transform.position + _offsetSightEnemy)).normalized);
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
