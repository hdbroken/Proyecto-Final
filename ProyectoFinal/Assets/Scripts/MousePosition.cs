using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    // Update is called once per frame
    void Update()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;


        Ray ray = _camera.ScreenPointToRay(new Vector2(x,y));
        if (Physics.Raycast(ray,out RaycastHit hit))
        {
            transform.position = hit.point;
        }
    }
}
