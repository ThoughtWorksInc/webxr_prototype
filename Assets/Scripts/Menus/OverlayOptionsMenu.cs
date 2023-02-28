using UnityEngine;
using TMPro;

public class OverlayOptionsMenu : MonoBehaviour
{
    public GameObject buttonTemplate;

    private string[] overlays = new string[]
    {
        "Text",
        "Image"
    };

    void Start()
    {
        foreach (string overlay in overlays)
        {
            GameObject g = Instantiate(buttonTemplate, transform);
            g.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = overlay;
        }

        buttonTemplate.SetActive(false);
    }
}
