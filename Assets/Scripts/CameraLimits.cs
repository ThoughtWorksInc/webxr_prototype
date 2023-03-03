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

    public void CameraStart()
    {
        Camera.main.transform.position = new Vector3(0, 1, -10);
        Camera.main.transform.rotation = new Quaternion(0, 0, 0, 0);
        start = true;
    }

}
