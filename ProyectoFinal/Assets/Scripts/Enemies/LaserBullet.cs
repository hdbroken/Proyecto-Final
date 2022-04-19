using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    [SerializeField]
    protected LaserBulletData _laserBullet;

    private Vector3 _direction;

    private void Start()
    {
        Destroy(transform.parent.gameObject, 3f);
    }

    void Update()
    {
        if (GameManager.instance.playerIsAlive)
        {
            Move();
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }
    }

    public void DirectionToShoot(Vector3 direction)
    {
        _direction = direction.normalized;
    }

    private void Move()
    {
        transform.position += (_direction * _laserBullet.speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy"))
           Destroy(transform.parent.gameObject);
    }
}
