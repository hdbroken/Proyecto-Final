using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    
    [SerializeField]
    private float _viewDistance;
    private float _viewDistance = 7;

    [SerializeField]
    private float _viewAngle;
    private float _viewAngle = 45;

    [SerializeField]
    private float _shootDistance = 5;

    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _viewDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _shootDistance);

        Vector3 fovLine1 = Quaternion.AngleAxis(_viewAngle, transform.up) * transform.forward * _viewDistance;
        Vector3 fovLine2 = Quaternion.AngleAxis(-_viewAngle, transform.up) * transform.forward * _viewDistance;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);

        if (_player != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, (_player.transform.position - transform.position).normalized * _viewDistance);
        }

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * _viewDistance);
    }
    
    public bool IsInShootingRange()
    {
        float distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position);
        if (IsInLOS() && (distanceToPlayer <= _shootDistance))
        {
            return true;
        }
        else return false;
    }
    public bool IsInLOS()
    {
        Vector3 playerPosition = new Vector3();
        Vector3 directionToPlayer = new Vector3();

        playerPosition = _player.transform.position;
        float distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position);
        

        directionToPlayer = (_player.transform.position - transform.position).normalized;

        if (distanceToPlayer <= _viewDistance)
        {
            if (PlayerIsBetweenAngles(directionToPlayer))
            {
                if (ICanSeePlayer(directionToPlayer))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        else
            return false;
    }

    private bool ICanSeePlayer(Vector3 directionToPlayer)
    {
        RaycastHit hit;
        bool esta = Physics.Raycast(transform.position, directionToPlayer, out hit, _viewDistance);
        if (esta)
        {
            if (hit.transform == _player.transform)
            {
                return true;
            }
            else return false;
        }
        else return false;
    }

    private bool PlayerIsBetweenAngles(Vector3 directionToPlayer)
    {
        float p = ((transform.forward.x * directionToPlayer.x) + (transform.forward.y * directionToPlayer.y) + (transform.forward.z * directionToPlayer.z));
        float cosX = p / (transform.forward.magnitude * directionToPlayer.magnitude);
        float angle = Mathf.Acos(cosX) * Mathf.Rad2Deg;

        if (angle < _viewAngle)
            return true;
        else
            return false;
    }
}

