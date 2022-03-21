using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New fov Data", menuName = "Create fov Data")]
public class FieldOfViewData : ScriptableObject
{
    
    [SerializeField]
    private float _viewDistance = 7;

    [SerializeField]
    private float _viewAngle = 90;

    [SerializeField]
    private float _shootDistance = 5;

    [SerializeField]
    private float _speedToRotation = 10;

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
