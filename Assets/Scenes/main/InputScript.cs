using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputScript : MonoBehaviour
{   
    GameObject overlay;
    public TextMeshProUGUI title;
    public TMP_InputField inputText;

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
        this.gameObject.SetActive(true);
        overlay = referenceObj;

        title.text = "Edit Text for element: " + overlay.name;
        inputText.text = overlay.GetComponentInChildren<TextMeshProUGUI>().text;
    }

    public void SaveTextInput()
    {
        overlay.GetComponentInChildren<TextMeshProUGUI>().text = inputText.text;
        Debug.Log("Text successfully updated for element: " + overlay.name);

        overlay = null;
        inputText.text = "";
        this.gameObject.SetActive(false);
    }
}
