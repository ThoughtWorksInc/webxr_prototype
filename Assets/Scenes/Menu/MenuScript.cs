using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject buttonTemplate;

    private string[] scenes = new string[]
    {
        "TrainerScene",
        "TrainingScene"
        //"SpikeMenu"
    };

    // Start is called before the first frame update
    void Start()
    {
        GameObject g;

        foreach (string scene in scenes)
        {
            g = Instantiate(buttonTemplate, transform);
            g.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = scene;
            g.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(scene));
        }

        Destroy(buttonTemplate);
    }
}
