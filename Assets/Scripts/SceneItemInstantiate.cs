using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneItemInstantiate : MonoBehaviour
{
    //Temporary
    public GameObject SceneObject;

    public List<SceneItem> SceneItems = new();

    void Start()
    {
        SceneItems.Add(new SceneItem(SceneObject, SceneObject.transform));

        SceneItems.ForEach(delegate (SceneItem item) {
            _ = Instantiate(item.SceneObject, item.SceneObject.transform.position, item.SceneObject.transform.rotation);
        });
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.M))
        {
            SceneManager.LoadScene("SpikeMenu");
        }
    }
}