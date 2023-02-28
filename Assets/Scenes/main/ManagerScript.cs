using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    Camera mainCamera;
    public GameObject popUpPanel;

    void Start()
    {
        mainCamera = Camera.main;
    }
    public void SwitchScene()
    {   
        SceneManager.LoadScene("TraineeScene");
    }

    public void SaveScene(){
        Debug.Log("Save scene");
        OverlaysData overlayData = new OverlaysData();
        
        string textPrefab = "Text";
        GameObject textGameObject = Resources.Load(textPrefab) as GameObject;

        if(textGameObject!=null)
        {
            foreach (var gameobj in GameObject.FindGameObjectsWithTag("Text_Overlay"))
            {  
                OverlayGameObject overlayGameObject = new OverlayGameObject();
                overlayGameObject.type = "Text";
                overlayGameObject.userInput = gameobj.GetComponentInChildren<TextMeshProUGUI>().text;
                overlayGameObject.position = gameobj.transform.position;
                overlayGameObject.scale = gameobj.transform.localScale;
                overlayGameObject.rotation = gameobj.transform.rotation;
                overlayData.myOverlays.Add(overlayGameObject);
            }
        }

        string imagePrefab = "Image";
        GameObject imageGameObject = Resources.Load(imagePrefab) as GameObject;

        if(imageGameObject!=null)
        {
            foreach (var gameobj in GameObject.FindGameObjectsWithTag("Image_Overlay"))
            {
                Texture2D texture = gameobj.GetComponentInChildren<Image>().sprite.texture;

                string trainingId = AWSManager.Instance.uniqueId;

                string filename = AWSManager.Instance.UploadImage(texture, gameobj.name+"_texture_"+trainingId);

                OverlayGameObject overlayGameObject = new OverlayGameObject();
                overlayGameObject.type = "Image";
                // change this to whatever you need for accessing image
                overlayGameObject.userInput = filename;
                overlayGameObject.position = gameobj.transform.position;
                overlayGameObject.scale = gameobj.transform.localScale;
                overlayGameObject.rotation = gameobj.transform.rotation;
                overlayData.myOverlays.Add(overlayGameObject);
        
            }
        }

        string json = JsonUtility.ToJson(overlayData);
        string training_id = AWSManager.Instance.PostRequest(json);

        GameObject popupElement = Instantiate(popUpPanel, mainCamera.transform.position + (mainCamera.transform.forward * 3), mainCamera.transform.rotation);
        popupElement.GetComponent<PopUp>().SetTrainingId(training_id);
        
        Debug.Log("Training id: " + training_id);
    }
}
