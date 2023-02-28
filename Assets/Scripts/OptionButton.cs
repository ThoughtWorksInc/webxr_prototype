using System.Collections;
using System.Collections.Generic;
using RTG;
using TMPro;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    Camera mainCamera;
    TextMeshProUGUI text;
    int counter;

    // Start is called before the first frame update
    void Start()
    {   
        counter = 1;
        mainCamera = Camera.main;
        text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    
    public void InstantiateResource()
    {
        GameObject data = Resources.Load<GameObject>(text.text);
        GameObject element = Instantiate(data, mainCamera.transform.position + (mainCamera.transform.forward * 3), mainCamera.transform.rotation);
        element.name = text.text + "_" + counter;
        counter += 1;

        ObjectTransformGizmo transformGizmo = RTGizmosEngine.Get.CreateObjectUniversalGizmo();
        transformGizmo.SetTargetObject(element);

        GameObject.Find("ObjectsList").GetComponent<ObjectList>().AddObject(element);
        
    }
}
