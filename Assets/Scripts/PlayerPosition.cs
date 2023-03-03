using UnityEngine;

[System.Serializable]
public class PlayerPosition{
    public Vector3 position;
    public Quaternion rotation;

    public PlayerPosition()
    {
        position = new Vector3(0, 1, -10);
        rotation = new Quaternion(0,0,0,0);
    }
}