using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectButton : MonoBehaviour
{   
    public GameObject overlayReference;
    
    // Start is called before the first frame update
    public void ButtonClick()
    {   
        // later check if overlayReference.type to decide which input panel to show

        GameObject InputPanel = GameObject.Find("InvisiblePanel").transform.GetChild(0).gameObject;
        InputPanel.GetComponent<InputScript>().showInputPanel(overlayReference);
    }
}
