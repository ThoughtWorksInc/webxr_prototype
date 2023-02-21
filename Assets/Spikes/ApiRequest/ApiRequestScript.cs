using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class ApiRequestScript : MonoBehaviour
{
    public TextMeshProUGUI text;


    void Start()
    {
        StartCoroutine(GetRequest("https://tobuk8o9zg.execute-api.eu-west-1.amazonaws.com/prod"));
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

        text.text = response;
        webRequest.Dispose();
    }
}
