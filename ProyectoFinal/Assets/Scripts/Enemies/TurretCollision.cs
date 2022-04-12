using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCollision : MonoBehaviour
{
    [SerializeField]
    private float _timeDesactivated = 5f;

    private Turret _turret;

    private float _timer = 0;

    public float timer
    {
        get { return _timer; }
        set { _timer = value; }
    }

    public float timeDesactivated
    {
        get { return _timeDesactivated; }
        set { _timeDesactivated = value; }
    }

    private void Awake()
    {
        _turret = GetComponentInChildren<Turret>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
    }

    IEnumerator TimeDesactivated()
    {
        float timer = 0f;
        StartCoroutine(MoveDown());
        while (timer < _timeDesactivated - 2)
        {
            timer += 1;
            yield return new WaitForSeconds(1f);
        }
        StartCoroutine(MoveUp());        
        yield return null;
    }

    public void Desactivate()
    {
        _turret.isActivated = false;              
        StartCoroutine(TimeDesactivated());        
    }

    IEnumerator MoveDown()
    {
        Vector3 rotation = transform.eulerAngles;
        float moveX = rotation.x;
        Debug.Log(rotation);
        
        while (moveX < 30)
        {
            moveX += 0.25f;
            transform.rotation = Quaternion.Euler(moveX, rotation.y, rotation.z);
            yield return new WaitForSeconds(0.008f);
        }                    
        yield return null;
    }

    IEnumerator MoveUp()
    {
        Vector3 rotation = transform.eulerAngles;
        float moveX = rotation.x;
        while (moveX > 0)
        {
            moveX -= 0.25f;
            transform.rotation = Quaternion.Euler(moveX, rotation.y, rotation.z);
            yield return new WaitForSeconds(0.008f);
        }
        transform.rotation = Quaternion.Euler(0, rotation.y, rotation.z);
        _turret.isActivated = true;
        yield return null;
    }
}
