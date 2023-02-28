using RTG;
using TMPro;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    TextMeshProUGUI text;
    Camera mainCamera;
    int counter;

    void Start()
    {   
        mainCamera = Camera.main;
        text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        counter = 1;
    }

    public void InstantiateResource()
    {
        string overlayName = text.text;

        GameObject overlayResource = Resources.Load<GameObject>(overlayName);
        GameObject overlay = Instantiate(overlayResource, mainCamera.transform.position + (mainCamera.transform.forward * 3), mainCamera.transform.rotation);
        overlay.name = overlayName + "_" + counter++;

        ObjectTransformGizmo transformGizmo = RTGizmosEngine.Get.CreateObjectUniversalGizmo();
        transformGizmo.SetTargetObject(overlay);

        GameObject.Find("OverlayList").GetComponent<OverlayList>().AddObject(overlay);
    }
}
