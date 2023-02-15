using UnityEngine;
using UnityEngine.SceneManagement;

// Set Sphere scale using MyData.json saved on Start Scene

public class ScaleSphere : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string json = System.IO.File.ReadAllText(Application.dataPath + "/Spikes/SaveData/MyData.json");
        MyData data = JsonUtility.FromJson<MyData>(json);
        int myValue = data.myVariable;

        transform.localScale = Vector3.one * myValue;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.N))
        {
            SceneManager.LoadScene("SaveScene");
        }
    }
}
