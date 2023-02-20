using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadTraining : MonoBehaviour
{
    public List<SceneItem> SceneItems = new();
    public List<OverlayGameObject> myOverlays;

    void Start()
    {   
        string loadJson = System.IO.File.ReadAllText(Application.dataPath + "/Scenes/main/MyOverlaysData.json");
        OverlaysData myOverlaysData = JsonUtility.FromJson<OverlaysData>(loadJson);
        myOverlays = myOverlaysData.myOverlays;

        foreach (var item in myOverlays)
        {
            GameObject textPrefab = Resources.Load<GameObject>(item.type);

            if (textPrefab == null)
            {
                Debug.LogError("Failed to load text prefab.");
            }
            else
            {
                GameObject newTextObject = Instantiate(textPrefab, item.position, item.rotation);
                newTextObject.transform.localScale = item.scale;
                SceneItems.Add(new SceneItem(newTextObject, newTextObject.transform));
            }
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

