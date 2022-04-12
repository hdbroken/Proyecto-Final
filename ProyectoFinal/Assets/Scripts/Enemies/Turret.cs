using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : EnemyBase
{
    [SerializeField]
    private GameObject _firePoint;

    [SerializeField]
    private GameObject _laserBullet;

    [SerializeField]
    private float maxIntensityChargeWeapon;
    
    private GameObject _target;  
    
    private Light _chargeWeapon;

    private bool _isActivated = true;
    
    public bool isActivated
    {
        get { return _isActivated; }
        set { _isActivated = value; }
    }
    
    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        _chargeWeapon = GetComponentInChildren<Light>();        
    }
 
    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            if (IsInLOS(_target))
            {
                ChargeWeapon();
                LookPlayer();
                if (IsInShootingRange(_target))
                {
                    Shoot();
                }
            }
            else if (!IsInLOS(_target))
            {
                DisChargeWeapon();
            }
        }
    }

    private void LookPlayer()
    {
        Quaternion targetRotation = Quaternion.LookRotation(_target.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _fov.speedToRotation);
    }

    private void Shoot()
    {
       GameObject bullet = Instantiate(_laserBullet, _firePoint.transform.position,transform.rotation);
       LaserBullet laser = bullet.GetComponentInChildren<LaserBullet>();
       laser.DirectionToShoot( (_target.transform.position - transform.position).normalized);        
    }

    private void ChargeWeapon()
    {
        if (_chargeWeapon.intensity <= maxIntensityChargeWeapon)
        {
            _chargeWeapon.intensity += 10 * Time.deltaTime;
        }
    }

    private void DisChargeWeapon()
    {
        if (_chargeWeapon.intensity >= 0)
        {
            _chargeWeapon.intensity -= 10 * Time.deltaTime;
        }
    }
}
