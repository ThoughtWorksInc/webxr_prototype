using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    public void SwitchScene()
    {   
        SceneManager.LoadScene("TraineeScene");
    }

    public void SaveScene(){
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

        string training_id = AWSManager.Instance.saveJsonFileToS3(json);

        Debug.Log("Training id: " + training_id);
    }
}
