using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using System.Collections;
using UnityEngine.Networking;

public class ImageInputPanelScript : MonoBehaviour, IInputPanel
{
    GameObject overlay;

    public TextMeshProUGUI title;
    public TextMeshProUGUI pathText;
    public Button saveButton;

    private string imagePath = "";
    private Image image;
    private Texture2D texture;
    void Start()
    {
    }

    public void ShowInputPanel(GameObject referenceObj)
    {
        this.gameObject.GetComponentInParent<PanelController>().SetPanelActive(this.gameObject.name);
        overlay = referenceObj;
        title.text = "Edit Image for: " + overlay.name;

        #if UNITY_EDITOR
            imagePath = AssetDatabase.GetAssetPath(overlay.GetComponentInChildren<Image>().sprite);
        #endif
    }

    public void OpenFileExplorer()
    {
    #if UNITY_EDITOR
            imagePath = EditorUtility.OpenFilePanel("Select image", "", "png,jpg,jpeg");
            saveButton.interactable = true;
    #else
        FileUploaderHelper.RequestFile((path) => 
            {
                if (string.IsNullOrWhiteSpace(path))
                    return;

                StartCoroutine(UploadImage(path));  
                imagePath = path;
                pathText.text = imagePath;
                saveButton.interactable = true;
            });
        #endif

        pathText.text = imagePath;
    }

    public void SaveImageInput()
    {
        #if UNITY_EDITOR
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
            overlay.GetComponent<ImageOverlay>().HideDefaultElements();
        }
        #else
            overlay.GetComponentInChildren<Image>().sprite = Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f));
            overlay.GetComponent<ImageOverlay>().HideDefaultElements();
        #endif

        imagePath = "Select a file";
        pathText.text = imagePath;
        overlay = null;

        saveButton.interactable = false;
        this.gameObject.SetActive(false);
    }

    // Coroutine for image upload
    IEnumerator UploadImage(string path)
    {
        // This is where the texture will be stored.
        
        // path = path.Substring(path.IndexOf(":") + 1);
        Debug.Log("Path: " + path);
        // using to automatically call Dispose, create a request along the path to the file
        using (UnityWebRequest imageWeb = new UnityWebRequest(path, UnityWebRequest.kHttpVerbGET))
        {
            // We create a "downloader" for textures and pass it to the request
            imageWeb.downloadHandler = new DownloadHandlerTexture();
            Debug.Log("waiting for imageWeb.SendWebRequest()");
            // We send a request, execution will continue after the entire file have been downloaded
            yield return imageWeb.SendWebRequest();

            // Getting the texture from the "downloader"
            texture = ((DownloadHandlerTexture)imageWeb.downloadHandler).texture;
            Debug.Log("Got texture back from browser");
        }
        Debug.Log("Going to apply texture to overlay now");

        // Create a sprite from a texture and pass it to the avatar image on the UI
        
    }

    public void ClosePanel()
    {
        this.gameObject.SetActive(false);
    }
}