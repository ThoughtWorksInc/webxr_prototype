using UnityEngine;

public class CameraLimits : MonoBehaviour
{
    public bool start = false;

    void Update()
    {
        if(start)
        {
            if (this.transform.position.y < 1.2)
            {
                this.transform.position = new Vector3(transform.position.x, 1.2f, transform.position.z);
            }

            if (this.transform.position.y > 1.6)
            {
                this.transform.position = new Vector3(transform.position.x, 1.6f, transform.position.z);
            }
        }
    }

    public void CameraStart(PlayerPosition playerPosition)
    {
        Camera.main.transform.position = playerPosition.position;
        Camera.main.transform.rotation = playerPosition.rotation;
        start = true;
    }

}
