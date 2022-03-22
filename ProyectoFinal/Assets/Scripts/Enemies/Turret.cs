using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : EnemyBase
{
    private GameObject _target;   


    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player");            
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsInLOS(_target))
        {
            LookPlayer();
            if (IsInShootingRange(_target))
            Shoot();
        }
    }

    private void LookPlayer()
    {
        Quaternion targetRotation = Quaternion.LookRotation(_target.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _fov.speedToRotation);
    }

    private void Shoot()
    {

        Debug.Log("Estas Muerto");
    }
}
