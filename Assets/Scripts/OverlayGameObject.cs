using UnityEngine;

[System.Serializable]
public class OverlayGameObject{
    public string type;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    // this userInput will always be a storng. For textoverlay its text, 
    // for imageoverlay its a path to AWS image location
    public string userInput;
}