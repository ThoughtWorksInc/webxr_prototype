using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectList : MonoBehaviour
{   
    public List<GameObject> myObjects;
    // Start is called before the first frame update
    void Start()
    {
        myObjects = new List<GameObject>();
    }

    public void AddObject(GameObject obj)
    {
        myObjects.Add(obj);
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject g;
        g = Instantiate(buttonTemplate, transform);
        g.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = obj.name;
        g.GetComponent<ObjectButton>().overlayReference = obj;
    }

}
