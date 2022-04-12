using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Laser Bullet Data", menuName = "Create Laser Bullet Data")]
public class LaserBulletData : ScriptableObject
{
    [SerializeField]
    private float _speed = 30f;

    public float speed
        {
        get { return _speed; }
        }
}
