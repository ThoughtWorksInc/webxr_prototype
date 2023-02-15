using UnityEngine;

public class SceneItem
{
    public GameObject SceneObject;
    public Transform ObjectTransform;

    public SceneItem(GameObject sceneObject, Transform transform)
    {
        this.SceneObject = sceneObject;
        this.ObjectTransform = transform;
    }
}