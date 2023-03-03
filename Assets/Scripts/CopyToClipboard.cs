using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class CopyToClipboard : MonoBehaviour
{
    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}

public static class CopyToClipboardHelper
{
    static CopyToClipboard copyObject;
    static CopyToClipboardHelper()
    {
        var wrapperGameObject = new GameObject("copyObject", typeof(CopyToClipboard));
        copyObject = wrapperGameObject.GetComponent<CopyToClipboard>();
    }


    public static void Copy(string textToCopy)
    {
        BrowserCopyToClipboard(textToCopy);
    }

    // Below we declare external functions from our .jslib file
    [DllImport("__Internal")]
    private static extern void BrowserCopyToClipboard(string textToCopy);
}


