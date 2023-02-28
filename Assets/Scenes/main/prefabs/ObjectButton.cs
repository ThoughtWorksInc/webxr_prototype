using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectButton : MonoBehaviour
{   
    public GameObject overlayReference;
    public string overlayReferenceType;
    
    // Start is called before the first frame update
    public void ButtonClick()
    {   
        if (overlayReferenceType.Equals("textobj"))
        {
            GameObject InputPanel = GameObject.Find("InvisiblePanel").transform.GetChild(0).gameObject;
            InputPanel.GetComponent<InputScript>().showInputPanel(overlayReference);
        }
        else
        {
            GameObject InputPanel = GameObject.Find("ImageInvisiblePanel").transform.GetChild(0).gameObject;
            InputPanel.GetComponent<ImageScript>().showInputPanel(overlayReference);
        }
    }
}
