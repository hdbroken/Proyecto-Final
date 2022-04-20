using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private Transform _shootPoint;

    [SerializeField]
    private float _distance = 10000;

    private LineRenderer laser;
    private float timer;

    private void Awake()
    {
        laser = GetComponent<LineRenderer>();
    }

    private bool CanShoot()
    {
        if ( Input.GetKey(KeyCode.Mouse1)) return true;
        else
        if (Input.GetKeyUp(KeyCode.Mouse1)) return false;
        else return false;
    }
    public void Shooting(Camera player)
    {
        if (CanShoot())
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
            {
                laser.SetPosition(0, (_shootPoint.position /*+ new Vector3(0, -1, 0.1f)*/));
                laser.SetPosition(1, _shootPoint.forward * _distance);

                RaycastHit hit;

                if (Physics.Raycast(_shootPoint.position, _shootPoint.forward, out hit))
                {
                    var gObj = hit.collider.gameObject;
                    if (gObj.CompareTag("Face"))
                    {
                        timer += Time.deltaTime;
                        Debug.Log($"tiempo continuo {timer}");
                        if (timer >= 2)
                        {

                            var script = gObj.GetComponent<FacePatrolBehavior>();

                            if (null != script)
                            {
                                script.shoot();
                            }
                            if (hit.collider)
                            {
                                laser.SetPosition(1, hit.point);
                            }
                            timer = 0;
                        }
                    }
                    if (gObj.CompareTag("Enemy"))
                    {
                        TurretCollision turretCollision = gObj.GetComponent<TurretCollision>();
                        Turret turret = gObj.GetComponent<Turret>();
                        EnemyCollision enemyCollision = gObj.GetComponent<EnemyCollision>();

                        if ((turretCollision != null) && (turret.isActivated))
                            turretCollision.Desactivate();
                        else if ((enemyCollision != null))
                            enemyCollision.Desactivate();
                    }
                }
            }
            else
            {
                laser.SetPosition(0, _shootPoint.position);
                laser.SetPosition(1, _shootPoint.position);
            }
        }
    }
}
