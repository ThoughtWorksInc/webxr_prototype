using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ManagerScript : MonoBehaviour
{
    public void SaveAndSwitchScene()
    {
        OverlaysData overlayData = new OverlaysData();
        overlayData.myOverlays = GameObject.FindGameObjectsWithTag("Overlays");

        string json = JsonUtility.ToJson(overlayData);
        System.IO.File.WriteAllText(Application.dataPath + "/Spikes/week1/MyOverlaysData.json", json);

        foreach (var overlay in overlayData.myOverlays)
        {
            DontDestroyOnLoad(overlay);
        }

        SceneManager.LoadScene("TraineeScene");
    }
}
