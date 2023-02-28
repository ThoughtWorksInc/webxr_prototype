using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosePopup : MonoBehaviour
{
    public void destroyPopup()
    {
        GameObject popupPrefab = GameObject.FindGameObjectWithTag("PopupPrefab");
        Destroy(popupPrefab);
    }

}
