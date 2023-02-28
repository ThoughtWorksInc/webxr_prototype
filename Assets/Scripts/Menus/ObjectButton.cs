using UnityEngine;

public class ObjectButton : MonoBehaviour
{   
    public GameObject overlayReference;
    
    public void ButtonClick()
    {   
        if (overlayReference.CompareTag("Text_Overlay"))
        {
            GameObject InputPanel = GameObject.Find("InvisiblePanel").transform.GetChild(0).gameObject;
            InputPanel.GetComponent<TextInputPanelScript>().ShowInputPanel(overlayReference);
        }
        else
        {
            GameObject InputPanel = GameObject.Find("InvisiblePanel").transform.GetChild(1).gameObject;
            InputPanel.GetComponent<ImageInputPanelScript>().ShowInputPanel(overlayReference);
        }
    }
}
