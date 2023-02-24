using System.Collections.Generic;
using UnityEngine;

public class LoadAugmentation : MonoBehaviour
{
    public List<SceneItem> SceneItems = new();

    void Start()
    {   
        string loadJson = System.IO.File.ReadAllText(Application.dataPath + "/Spikes/Recreate_Augmentation/MySceneData.json");
        MySceneData mySceneData = JsonUtility.FromJson<MySceneData>(loadJson);

        // get gameObject out of our JSON data file
        GameObject cube = mySceneData.myObject;

        // do the same as Debora's instantiate script, this even uses the same SceneItem class from the other folder
        SceneItems.Add(new SceneItem(cube, cube.transform));

        SceneItems.ForEach(delegate (SceneItem item) {
            _ = Instantiate(item.SceneObject, item.SceneObject.transform.position, item.SceneObject.transform.rotation);
        });
    }
}
