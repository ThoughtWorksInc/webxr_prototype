using RTG;
using UnityEngine;

public class ItemGizmos : MonoBehaviour
{
    ObjectTransformGizmo transformGizmo;

    private void Start()
    {
       transformGizmo = RTGizmosEngine.Get.CreateObjectUniversalGizmo();
    }

    public void PlaceGizmos(GameObject item)
    {
        
        transformGizmo.SetTargetObject(item);
    }
}
