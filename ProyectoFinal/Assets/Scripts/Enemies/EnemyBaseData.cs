using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Create Enemy Data")]
public class EnemyBaseData : ScriptableObject
{
    
    [SerializeField]
    private float _viewDistance = 10;

    [SerializeField]
    private float _viewAngle = 90;

    [SerializeField]
    private float _shootDistance = 7;

    [SerializeField]
    private float _speedToRotation = 15;

    public float viewDistance
    {
        get { return _viewDistance; }      
    }
    public float viewAngle
    {
        get { return _viewAngle/2; }      
    }
    public float shootDistance
    {
        get { return _shootDistance; }      
    }

    public float speedToRotation
    {
        get { return _speedToRotation; }        
    }

}
