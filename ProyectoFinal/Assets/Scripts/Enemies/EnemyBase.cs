using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{ 
    [SerializeField]
    protected EnemyBaseData _fov;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _fov.viewDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _fov.shootDistance);

        Vector3 fovLine1 = Quaternion.AngleAxis(_fov.viewAngle, transform.up) * transform.forward * _fov.viewDistance;
        Vector3 fovLine2 = Quaternion.AngleAxis(-_fov.viewAngle, transform.up) * transform.forward * _fov.viewDistance;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);
        
        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * _fov.viewDistance);
    }
    
    public bool IsInShootingRange(GameObject target)
    {
        float distanceToPlayer = Vector3.Distance(target.transform.position, transform.position);
        if (IsInLOS(target) && (distanceToPlayer <= _fov.shootDistance))
        {
            return true;
        }
        else return false;
    }
    public bool IsInLOS(GameObject target)
    {
        Vector3 targetPosition = new Vector3();
        Vector3 directionToTarget = new Vector3();

        targetPosition = target.transform.position;
        float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
        

        directionToTarget = (target.transform.position - transform.position).normalized;

        if (distanceToTarget <= _fov.viewDistance)
        {
            if (PlayerIsBetweenAngles(directionToTarget))
            {
                if (ICanSeePlayer(target,directionToTarget))
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

    private bool ICanSeePlayer(GameObject target, Vector3 directionToPlayer)
    {
        RaycastHit hit;
        bool esta = Physics.Raycast(transform.position, directionToPlayer, out hit, _fov.viewDistance);
        if (esta)
        {
            if (hit.transform == target.transform)
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

        if (angle < _fov.viewAngle)
            return true;
        else
            return false;
    }
}

