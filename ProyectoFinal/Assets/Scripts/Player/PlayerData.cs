using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Create Player Data")]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private float _gravity = 9.8f;
    public float gravity
    {
        get { return _gravity; }        
    }

    [Header("Movement")]
    [SerializeField]
    private float _walkSpeed = 5;
    [SerializeField]
    private float _runSpeed = 10;
    public float walkSpeed
    {
        get { return _walkSpeed; }
        set { _walkSpeed = value; }
    }
    public float runSpeed
    {
        get { return _runSpeed; }
        set { _runSpeed = value; }
    }

    [Header("Mouse Movement")]
    [SerializeField]
    private float _horizontalSensitivity = 5;
    [SerializeField]
    private float _verticalSensitivity = 5;
    public float horizontalSensitivity
    {
        get { return _horizontalSensitivity; }
        set { _horizontalSensitivity = value; }
    }
    public float verticalSensitivity
    {
        get { return _verticalSensitivity; }
        set { _verticalSensitivity = value; }
    }

    [Header("Vertical Anlges of Vision")]
    [SerializeField]
    private float _limitHeadUp = 60;
    [SerializeField]
    private float _limitHeadDown = 60;
    public float limitHeadUp
    {
        get { return _limitHeadDown; }
        set { _limitHeadDown = value; }
    }
    public float limitHeadDown
    {
        get { return -_limitHeadUp; }
        set { _limitHeadUp = value; }
    }
}
