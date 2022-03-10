using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    float timer;
    bool timeUp;

    [SerializeField] GameObject[] enemyPatrolRNG;
    void Start()
    {
    }

    void Update()
    {
        timer = timer + Time.deltaTime;
        //Debug.Log("tiempo" + timer);
        Spawn();
    }
    void Spawn()
    {
        if (timer > 1)
        {
            timeUp = true;
            timer = 0;
        }
        else
        {
            timeUp = false;
        }

        if (timeUp)
        {
            int enemyIndex = Random.Range(0, enemyPatrolRNG.Length);
            Instantiate(enemyPatrolRNG[enemyIndex], transform);
        }
    }
}
