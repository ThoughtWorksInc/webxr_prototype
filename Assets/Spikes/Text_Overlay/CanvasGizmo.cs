using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTG;

public class CanvasGizmo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
        
        ObjectTransformGizmo transformGizmo = RTGizmosEngine.Get.CreateObjectUniversalGizmo();
        GameObject targetObject = GameObject.Find("Canvas");
        Debug.Log("Trying to give gizmo to:");
        Debug.Log(targetObject);
        transformGizmo.SetTargetObject(targetObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
