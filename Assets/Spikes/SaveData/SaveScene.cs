using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScene : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Start()
    {
        try
        {
            string loadJson = System.IO.File.ReadAllText(Application.dataPath + "/Spikes/SaveData/MyData.json");
            MyData data = JsonUtility.FromJson<MyData>(loadJson);
            text.text = "Scale: " + data.myVariable;
        }
        catch
        {
            text.text = "Scale not initiated";
        }
       
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.S))
        {
            Save();
        }
        if(Input.GetKeyUp(KeyCode.I))
        {
            Increase();
        }
        if (Input.GetKeyUp(KeyCode.N))
        {
            SceneManager.LoadScene("LoadScene");
        }
    }

    void Save()
    {
        Debug.Log("Save");

        MyData data = new MyData();
        data.myVariable = 5;

        text.text = "Scale: " + data.myVariable;
        
        Debug.Log(Application.dataPath);

        string json = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(Application.dataPath + "/Spikes/SaveData/MyData.json", json);
    }

    void Increase()
    {
        Debug.Log("Increase");

        string loadJson = System.IO.File.ReadAllText(Application.dataPath + "/Spikes/SaveData/MyData.json");
        MyData data = JsonUtility.FromJson<MyData>(loadJson);
        data.myVariable += 5;

        text.text = "Scale: " + data.myVariable;

        string saveJson = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(Application.dataPath + "/Spikes/SaveData/MyData.json", saveJson);
    }
}
