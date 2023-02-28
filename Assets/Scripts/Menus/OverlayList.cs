using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OverlayList : MonoBehaviour
{
    public GameObject buttonTemplate;
    public GameObject content;
    public List<GameObject> myObjects;
    
    void Start()
    {
        myObjects = new List<GameObject>();
    }

    public void AddObject(GameObject obj)
    {
        myObjects.Add(obj);

        GameObject g = Instantiate(buttonTemplate, content.transform);
        g.name = obj.name + "_button";
        g.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = obj.name;
        g.GetComponent<ObjectButton>().overlayReference = obj;

        g.gameObject.SetActive(true);
    }

}
