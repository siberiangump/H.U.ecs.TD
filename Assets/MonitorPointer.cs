using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorPointer : MonoBehaviour
{
    public Transform Target;
    public Camera Camera;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        bool rayHitSomeThing = Physics.Raycast(ray, out raycastHit);
        Debug.Log(raycastHit.point);
        if (rayHitSomeThing)
            Target.position = raycastHit.point;
    }
}
