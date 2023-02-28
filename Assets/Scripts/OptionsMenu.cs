using UnityEditor;
using UnityEngine;
using System.IO;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject g;

        g = Instantiate(buttonTemplate, transform);
        g.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Text";

        g = Instantiate(buttonTemplate, transform);
        g.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Image";

        Destroy(buttonTemplate);

    }
}
