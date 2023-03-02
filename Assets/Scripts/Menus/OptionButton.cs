using RTG;
using TMPro;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    Camera mainCamera;
    int counter;

    void Start()
    {   
        mainCamera = Camera.main;
        counter = 1;
    }

    public void InstantiateResource()
    {
        string overlayName = this.gameObject.name;

        GameObject overlayResource = Resources.Load<GameObject>(overlayName);
        GameObject overlay = Instantiate(overlayResource, mainCamera.transform.position + (mainCamera.transform.forward * 3), mainCamera.transform.rotation);
        overlay.name = overlayName + "_" + counter++;

        ObjectTransformGizmo transformGizmo = RTGizmosEngine.Get.CreateObjectUniversalGizmo();
        transformGizmo.SetTargetObject(overlay);

        GameObject.Find("OverlayList").GetComponent<OverlayList>().AddObject(overlay);
    }
}
