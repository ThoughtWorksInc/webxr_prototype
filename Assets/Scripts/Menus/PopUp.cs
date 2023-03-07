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
#if UNITY_EDITOR
        GUIUtility.systemCopyBuffer = text.text;
#else
        CopyToClipboardHelper.Copy(text.text);
#endif
    }
}
