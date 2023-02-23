using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class AWSTest : MonoBehaviour
{

    void Start()
    {
    }

    public void GetFile()
    {
        StartCoroutine(GetRequest("https://webxr-poc-data.s3.eu-west-1.amazonaws.com/training_3504309.json"));
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

            // Or retrieve results as binary data
            byte[] results = webRequest.downloadHandler.data;
        }

        webRequest.Dispose();
    }
}


//https://docs.aws.amazon.com/AmazonS3/latest/userguide/access-bucket-intro.html