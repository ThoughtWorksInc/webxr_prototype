using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectList : MonoBehaviour
{
    public GameObject buttonTemplate;
    public List<GameObject> myObjects;
    
    void Start()
    {
        myObjects = new List<GameObject>();
    }

    public void AddObject(GameObject obj)
    {
        myObjects.Add(obj);
        buttonTemplate = transform.GetChild(0).gameObject;
        GameObject g;
        g = Instantiate(buttonTemplate, transform);
        g.gameObject.SetActive(true);
        g.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = obj.name;
        
        if (obj.name.StartsWith("Text"))
        {
            g.GetComponent<ObjectButton>().overlayReferenceType = "textobj";
        }
        else
        {
            g.GetComponent<ObjectButton>().overlayReferenceType = "imageobj";
        }
        g.GetComponent<ObjectButton>().overlayReference = obj;
    }

}
