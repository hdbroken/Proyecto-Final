using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSavePoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SavePoint")) 
        {
            Debug.Log("Pasando punto de guardado " + other.name);
            SavePointManager ManageSave = other.transform.parent.GetComponent<SavePointManager>();
            ManageSave.FindSavePoint(other.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
