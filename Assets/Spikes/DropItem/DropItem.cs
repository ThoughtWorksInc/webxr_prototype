using System.Collections;
using System.Collections.Generic;
using RTG;
using TMPro;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    GameObject sceneManager;
    Camera mainCamera;
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        sceneManager = GameObject.Find("SceneManager");
    }

    
    public void InstantiateResource()
    {
        ObjectTransformGizmo transformGizmo = RTGizmosEngine.Get.CreateObjectUniversalGizmo();

        GameObject data = Resources.Load<GameObject>(text.text);
        sceneManager.GetComponent<ItemGizmos>().PlaceGizmos(data);

        _ = Instantiate(data, mainCamera.transform.position + (mainCamera.transform.forward * 3), mainCamera.transform.rotation);
    }
}
