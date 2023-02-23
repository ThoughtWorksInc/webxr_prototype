using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using TMPro;
using System.Collections.Generic;


public class TrainingScript : MonoBehaviour
{
    public TextMeshProUGUI inputText;
    private object data = null;
    public List<OverlayGameObject> myOverlays;
    public List<SceneItem> SceneItems = new();

    void Start()
    {
    }

    public void GetTraining()
    {
        // training_3504309.json

        // get id from text input field
        string training_id = inputText.text.ToString();
        var getURL = "https://webxr-poc-data.s3.eu-west-1.amazonaws.com/" + training_id + ".json";
        
        StartCoroutine(GetRequest(getURL.Replace("\u200B", "")));

    }

    IEnumerator GetRequest(string uri)
    {
        string response = "";
        UnityWebRequest webRequest = UnityWebRequest.Get(uri);

        webRequest.SetRequestHeader("Access-Control-Allow-Origin", "*");
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
            webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            response = webRequest.error;
            Debug.Log("Error: " + webRequest.error);
        }
        else
        {
            // Show results as text
            response = webRequest.downloadHandler.text;
            Debug.Log("Response: " + webRequest.downloadHandler.text);
            data = webRequest.downloadHandler.text;

            // Or retrieve results as binary data
            byte[] results = webRequest.downloadHandler.data;
        }

        webRequest.Dispose();
        // RecreateScene();
    }

    // void RecreateScene()
    // {   
    //     Debug.Log("DATA:" + data);
    //     Debug.Log("Type: " + data.GetType());
        
    //     object loadJson = JsonUtility.ToJson(data.ToString());
    //     Debug.Log("JSON:" + loadJson);
    //     foreach (var item in data["myOverlays"])
    //     {   
    //         Debug.Log(item);
    //     }
        

    //     // Debug.Log("JSON: " + loadJson);
    //     // OverlaysData myOverlaysData = JsonUtility.FromJson<OverlaysData>(data);
    //     // myOverlays = myOverlaysData.myOverlays;
    //     // Debug.Log(myOverlays);

    //     // Debug.Log("Recreating Scene...");
    //     // foreach (var item in myOverlays)
    //     // {   
    //     //     Debug.Log(item.type);
    //     //     GameObject textPrefab = Resources.Load<GameObject>(item.type);

    //     //     if (textPrefab == null)
    //     //     {
    //     //         Debug.LogError("Failed to load text prefab.");
    //     //     }
    //     //     else
    //     //     {
    //     //         GameObject newTextObject = Instantiate(textPrefab, item.position, item.rotation);
    //     //         newTextObject.transform.localScale = item.scale;
    //     //         SceneItems.Add(new SceneItem(newTextObject, newTextObject.transform));
    //     //     }
    //     // }

    //     // SceneItems.ForEach(delegate (SceneItem item) {
    //     //     _ = Instantiate(item.SceneObject, item.SceneObject.transform.position, item.SceneObject.transform.rotation);
    //     // });
    // }
}
