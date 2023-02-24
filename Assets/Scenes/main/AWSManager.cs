using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AWSManager : MonoBehaviour
{
    #region Singleton
    private static AWSManager _instance;

    private static string uniqueId;
    public static AWSManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("AWSManager is NULL");
            }
            return _instance;
        }
    }
    #endregion
    void Start(){
        _instance=this;
        uniqueId = (new System.Random().Next(1000000, 9999999)).ToString();
    }
    public string PostRequest(string json)
    {
        string contentType = "application/json";
        string target= uniqueId+".json";
        // Set the URL for the request
        string url = $"https://webxr-poc-data.s3.eu-west-1.amazonaws.com/"+target;

        // Read the contents of the JSON file
        string jsonContent = json;
        byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonContent);

        UnityWebRequest request = UnityWebRequest.Put(url, jsonBytes);
        request.SetRequestHeader("Content-Type", contentType);
        request.SetRequestHeader("Access-Control-Allow-Origin", "*");

        // Send the request and handle the response
        StartCoroutine(SendRequest(request));
        return uniqueId;
    }

    static IEnumerator SendRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error uploading JSON file: " + request.error);
        }
        else
        {
            Debug.Log("JSON file uploaded successfully!");
        }
    }

}

