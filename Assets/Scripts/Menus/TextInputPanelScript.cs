using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextInputPanelScript : MonoBehaviour, IInputPanel
{   
    GameObject overlay;
    public TextMeshProUGUI title;
    public TMP_InputField inputText;

    public void ShowInputPanel(GameObject referenceObj)
    {
        this.gameObject.GetComponentInParent<PanelController>().SetPanelActive(this.gameObject.name);

        overlay = referenceObj;
        title.text = "Edit Text for: " + overlay.name;
        inputText.text = overlay.GetComponentInChildren<TextMeshProUGUI>().text;
    }

    public void SaveTextInput()
    {
        overlay.GetComponentInChildren<TextMeshProUGUI>().text = inputText.text;
        overlay = null;
        inputText.text = "";
        this.gameObject.SetActive(false);
    }

    public void ClosePanel()
    {
        this.gameObject.SetActive(false);
    }
}
