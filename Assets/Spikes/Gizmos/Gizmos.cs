using UnityEngine;
using RTG;


public class Gizmos : MonoBehaviour
{
    private void Start()
    {
        ObjectTransformGizmo transformGizmo = RTGizmosEngine.Get.CreateObjectUniversalGizmo();
        GameObject targetObject = GameObject.Find("Cube");
        transformGizmo.SetTargetObject(targetObject);
    }
}
