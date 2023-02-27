using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputScript : MonoBehaviour
{   
    GameObject overlay;
    public TextMeshProUGUI inputText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showInputPanel(GameObject referenceObj)
    {
        // Debug.Log(inputText.text);
        // inputText.text = referenceObj.GetComponentInChildren<TextMeshProUGUI>().text;
        // Debug.Log(inputText.text);
        this.gameObject.SetActive(true);
        overlay = referenceObj;
        this.GetComponentInChildren<TextMeshProUGUI>().text = "Edit Text for element: " + overlay.name;
        
    }

    public void SaveTextInput()
    {
        // get user text input and update overlay text
        overlay.GetComponentInChildren<TextMeshProUGUI>().text = inputText.text;
        Debug.Log("Text successfully updated for element: " + overlay.name);
        // overlay = null;
        inputText.text = "poop";
        this.gameObject.SetActive(false);
    }
}
