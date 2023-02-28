using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextOverlay : MonoBehaviour, IOverlay
{
    public TextMeshProUGUI text;

    public void Setup(OverlayGameObject data)
    {
        text.text = data.userInput;
    }
}
