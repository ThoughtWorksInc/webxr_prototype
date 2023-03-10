using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ImageOverlay : MonoBehaviour, IOverlay
{
    public Image image;
    public GameObject icon;
    public GameObject text;

    // public byte[] imagedata;
    public IEnumerator Setup(OverlayGameObject data)
    {
        //Should implement image here
        Debug.Log("Data image" + data.userInput);
        string uri="https://webxr-poc-data.s3.eu-west-1.amazonaws.com/"+data.userInput;
        string response = "";
        UnityWebRequest webRequest = UnityWebRequest.Get(uri);

        webRequest.SetRequestHeader("Access-Control-Allow-Origin", "*");
        yield return webRequest.SendWebRequest();

        if (
            webRequest.result == UnityWebRequest.Result.ConnectionError
            || webRequest.result == UnityWebRequest.Result.ProtocolError
        )
        {
            response = webRequest.error;
            Debug.Log("Error fetching image. " + webRequest.error);
        }
        else
        {
            Debug.Log("Image fetch successfully");
            response = webRequest.downloadHandler.text;

            Texture2D texture = new Texture2D(20, 20);
            texture.LoadImage(webRequest.downloadHandler.data);

            // assign the texture to the RawImage component
            image.sprite = Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f)
            );

            HideDefaultElements();
            
        }

        webRequest.Dispose();
    }

    public void HideDefaultElements()
    {
        icon.SetActive(false);
        text.SetActive(false);
    }
}
