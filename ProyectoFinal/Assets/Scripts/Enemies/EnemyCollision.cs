using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField]
    private float _timeDesactivated = 5f;

    private NavMeshAgent _navigation;

    private Enemy _movement;

    private Animator _enemyAnimator;

    public float timeDesactivated
    {
        get { return _timeDesactivated; }
        set { _timeDesactivated = value; }
    }

    private void Awake()
    {
        _navigation = GetComponent<NavMeshAgent>();
        _movement = GetComponent<Enemy>();
        _enemyAnimator = GetComponentInChildren<Animator>();
    }

    IEnumerator TimeDesactivated()
    {        
        float timer = 0f;
        while (timer < _timeDesactivated)
        {
            timer += 1;
            yield return new WaitForSeconds(1f);
        }
        _movement.enabled = true;
        _navigation.isStopped = false;
        _enemyAnimator.SetBool("isDesactivated", false);
        yield return null;
    }

    public void Desactivate()
    {
        _enemyAnimator.SetBool("isDesactivated", true);
        _navigation.isStopped = true;
        _movement.enabled = false;
        StartCoroutine(TimeDesactivated());        
    }
}
