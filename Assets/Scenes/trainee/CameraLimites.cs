using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimites : MonoBehaviour
{
    void Update()
    {
        if(this.transform.position.y < 1)
        {
            this.transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);
        }

        if (this.transform.position.y > 2)
        {
            this.transform.position = new Vector3(transform.position.x, 2.0f, transform.position.z);
        }
    }
}
