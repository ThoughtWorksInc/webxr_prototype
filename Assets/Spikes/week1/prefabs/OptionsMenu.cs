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

        string path = Application.dataPath + "/Spikes/week1/Resources";
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] prefabInfo = dir.GetFiles("*.prefab");

        foreach(FileInfo prefab in prefabInfo)
        {
            g = Instantiate(buttonTemplate, transform);
            g.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = prefab.Name.Replace(".prefab", "");
        }

        Destroy(buttonTemplate);

    }
}
