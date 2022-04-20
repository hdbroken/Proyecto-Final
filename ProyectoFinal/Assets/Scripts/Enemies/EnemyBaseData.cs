using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Create Enemy Data")]
public class EnemyBaseData : ScriptableObject
{    
    [SerializeField]
    private float _viewDistance = 10;
    public float viewDistance
    {
        get { return _viewDistance; }
    }


    [SerializeField]
    private float _viewAngle = 90;
    public float viewAngle
    {
        get { return _viewAngle / 2; }
    }


    [SerializeField]
    private float _shootDistance = 7;
    public float shootDistance
    {
        get { return _shootDistance; }
    }


    [SerializeField]
    private float _timeBetweenShoots = 0.3f;
    public float timeBetweenShoots
    {
        get { return _timeBetweenShoots; }
    }


    [SerializeField]
    private float _speedToRotation = 15;   

    public float speedToRotation
    {
        get { return _speedToRotation; }        
    }

}
