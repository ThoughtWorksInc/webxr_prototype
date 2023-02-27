using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputScript : MonoBehaviour
{   
    GameObject overlay;
    public TextMeshProUGUI title;
    public TMP_InputField inputText;

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
        overlay = null;
        inputText.text = "";
        this.gameObject.SetActive(false);
    }
}
