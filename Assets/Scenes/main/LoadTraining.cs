using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadTraining : MonoBehaviour
{
    public List<SceneItem> SceneItems = new();
    public GameObject[] myOverlays;

    void Start()
    {   
        string loadJson = System.IO.File.ReadAllText(Application.dataPath + "/Scenes/main/MyOverlaysData.json");
        OverlaysData myOverlaysData = JsonUtility.FromJson<OverlaysData>(loadJson);
        myOverlays = myOverlaysData.myOverlays;
        
        foreach (var item in myOverlays)
        {
            SceneItems.Add(new SceneItem(item, item.transform));
        }

        SceneItems.ForEach(delegate (SceneItem item) {
            _ = Instantiate(item.SceneObject, item.SceneObject.transform.position, item.SceneObject.transform.rotation);
        });
    }

    void Update() 
    {
        if(Input.GetKeyUp("n")) {
            SceneManager.LoadScene("SpikeMenu");
        }
    }
}
