using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    public void SaveAndSwitchScene()
    {
        OverlaysData overlayData = new OverlaysData();

        foreach (var gameobj in GameObject.FindGameObjectsWithTag("Text_Overlay"))
        {
            OverlayGameObject overlayGameObject = new OverlayGameObject();
            overlayGameObject.type = "Text";
            overlayGameObject.position = gameobj.transform.position;
            overlayGameObject.scale = gameobj.transform.localScale;
            overlayGameObject.rotation = gameobj.transform.rotation;
            overlayData.myOverlays.Add(overlayGameObject);
        }
        foreach (var gameobj in GameObject.FindGameObjectsWithTag("Image_Overlay"))
        {
            OverlayGameObject overlayGameObject = new OverlayGameObject();
            overlayGameObject.type = "Image";
            overlayGameObject.position = gameobj.transform.position;
            overlayGameObject.scale = gameobj.transform.localScale;
            overlayGameObject.rotation = gameobj.transform.rotation;
            overlayData.myOverlays.Add(overlayGameObject);
        }
        string json = JsonUtility.ToJson(overlayData);
        System.IO.File.WriteAllText(Application.dataPath + "/Scenes/main/MyOverlaysData.json", json);

        SceneManager.LoadScene("TraineeScene");
    }
}
