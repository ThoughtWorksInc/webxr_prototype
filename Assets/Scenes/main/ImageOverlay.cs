using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageOverlay : MonoBehaviour, IOverlay
{
    public Image image;

    public void Setup(OverlayGameObject data)
    {
        //Should implement image here
        Debug.Log("Image Setup");
    }
}
