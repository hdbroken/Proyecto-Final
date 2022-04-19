using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointManager : MonoBehaviour
{
    [SerializeField] List<Transform> Savepoints = new List<Transform>();
    void Start()
    {
        foreach (Transform savepoints in transform)
        {
            Debug.Log(savepoints.name);
            Savepoints.Add(savepoints);
        }
    }
    void Update()
    {
    }
    public void FindSavePoint(string name) 
    {
        int indexSavePoint = Savepoints.FindIndex(item => item.name == name);
        GameManager.instance.lastSavePoint = indexSavePoint;
    }
}
