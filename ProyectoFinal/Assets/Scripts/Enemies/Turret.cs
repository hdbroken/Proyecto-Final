using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : EnemyBase
{
    [SerializeField]
    private Vector3 _offsetSightTurret = new Vector3(0f, -1.2f, 0f);

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

    private bool _canShoot = true;

    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        _chargeWeapon = GetComponentInChildren<Light>();        
    }
 
    // Update is called once per frame
    void Update()
    {
        if (isActivated && GameManager.instance.playerIsAlive)
        {
            if (IsInLOS(_target))
            {
                ChargeWeapon();
                LookPlayer();
                if (IsInShootingRange(_target) && (_canShoot)) 
                {
                    _canShoot = false;
                    Shoot();
                    StartCoroutine(TimeToNextShoot());
                }
            }
            else if (!IsInLOS(_target))
            {
                DisChargeWeapon();
            }
        }
    }

    IEnumerator TimeToNextShoot()
    {
        yield return new WaitForSeconds(_fov.timeBetweenShoots);
        _canShoot = true;
    }
 
    private void LookPlayer()
    {
        Quaternion targetRotation = Quaternion.LookRotation(_target.transform.position - (transform.position + _offsetSightTurret));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _fov.speedToRotation);
    }

    private void Shoot()
    {
       GameObject bullet = Instantiate(_laserBullet, _firePoint.transform.position,transform.rotation);
       LaserBullet laser = bullet.GetComponentInChildren<LaserBullet>();
       laser.DirectionToShoot( (_target.transform.position - (transform.position + _offsetSightTurret)).normalized);       
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
