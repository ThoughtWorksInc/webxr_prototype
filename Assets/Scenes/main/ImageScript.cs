using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class ImageScript : MonoBehaviour
{
    GameObject overlay;
    private string imagePath = "";

    private Image image; 

    public void showInputPanel(GameObject referenceObj)
    {
        this.gameObject.SetActive(true);

        overlay = referenceObj;

        Debug.Log("Sprite path: "+ AssetDatabase.GetAssetPath(overlay.GetComponentInChildren<Image>().sprite));

        imagePath = AssetDatabase.GetAssetPath(overlay.GetComponentInChildren<Image>().sprite);
        
    }

    public void OpenFileExplorer()
    {
        imagePath = UnityEditor.EditorUtility.OpenFilePanel("Select image", "", "png,jpg,jpeg");
        Debug.Log(imagePath); 

        transform.GetComponentInChildren<TextMeshProUGUI>().text = imagePath;
    }

    public void SaveImageInput()
    {
        if (imagePath.Length != 0)
        {
            // Load the image from file
            byte[] imageData = File.ReadAllBytes(imagePath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageData);
            Debug.Log(overlay.GetComponentInChildren<Image>().sprite);
            // Display the image in the UI image component
            overlay.GetComponentInChildren<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            Debug.Log(overlay.GetComponentInChildren<Image>().sprite);
        }

        imagePath = "";
        Debug.Log("Image saved", overlay.GetComponentInChildren<Image>());
        overlay = null;
        this.gameObject.SetActive(false);
    }
    private Texture2D LoadTexture(string path)
    {
        Texture2D texture = null;

        if (!string.IsNullOrEmpty(path))
        {
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            texture = new Texture2D(2, 2);
            texture.LoadImage(bytes);
        }

        return texture;
    }
}