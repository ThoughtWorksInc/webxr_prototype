using TMPro;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void SetTrainingId(string trainingId)
    {
        text.text = trainingId;
    }

    public void ClosePopup()
    {
        Destroy(this.gameObject);
    }

    public void CopyIdButtonClick()
    {
        CopyToClipboardHelper.Copy(text.text);
    }
}
