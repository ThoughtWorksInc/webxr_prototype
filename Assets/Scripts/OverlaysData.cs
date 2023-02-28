using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public class OverlaysData
{
    public List<OverlayGameObject> myOverlays;
    public OverlaysData(){
        myOverlays = new List<OverlayGameObject>();
    }
}