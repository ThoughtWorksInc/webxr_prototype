using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveAugmentation : MonoBehaviour
{
    // Start is called before the first frame update

    // I initilize the cube object here so that I can call the DontDestroyOnLoad, otherwise compiler complains
    GameObject cube;
    void Start()
    {
        GameObject cube = GameObject.Find("Cube");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.S))
        {
            Save();
        }
        if(Input.GetKeyUp(KeyCode.N))
        {   
            // need to do this, otherwise unity cannot fwtch the GameObject from the instanceID we save in JSON data
            DontDestroyOnLoad(cube);
            SceneManager.LoadScene("RecreatedScene");
        }
    }

    void Save()
    {
        Debug.Log("SAVED CUBE POSITION");

        // Find the cube in the scene after doing all the transforms and moves 
        // this happens every time save is called by pressing S
        cube = GameObject.Find("Cube");

        // Create an instance of our data class, which for now only contains one GameObject
        // Unity keeps not the whole object, but in the file it's only an instanceID
        // It is importantt that Unity keeps the object, and doesnt delete it when leading a new 
        // scene, otherwise it will throw an NullReferenceException.

        // See inside Update Function, we have to call DontDestroyOnLoad function, which is built into unity by default
        MySceneData mySceneData = new MySceneData();
        mySceneData.myObject = cube;

        string json = JsonUtility.ToJson(mySceneData);
        System.IO.File.WriteAllText(Application.dataPath + "/Spikes/Recreate_Augmentation/MySceneData.json", json);
    }
}
