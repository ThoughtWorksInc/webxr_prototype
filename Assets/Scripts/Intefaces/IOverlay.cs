using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

interface IOverlay
{
    IEnumerator Setup(OverlayGameObject data);
}
