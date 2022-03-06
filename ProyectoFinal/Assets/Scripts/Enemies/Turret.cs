using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject _objective;
    private FieldOfView _turret;


    private void Awake()
    {
        _objective = GameObject.FindGameObjectWithTag("Player");        
        _turret = GetComponent<FieldOfView>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_turret.IsInLOS())
        {
            LookPlayer();
            Shoot();
        }
    }

    private void LookPlayer()
    {
        Quaternion targetRotation = Quaternion.LookRotation(_objective.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
    }

    private void Shoot()
    {

    }
}
