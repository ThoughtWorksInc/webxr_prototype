using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class CopyToClipboard : MonoBehaviour
{
    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void RequestCallback(string text)
    {
        CopyToClipboardHelper.SetResult(text);
    }
}

public static class CopyToClipboardHelper
{
    static CopyToClipboard copyObject;
    static Action<string> pathCallback;

    static CopyToClipboardHelper()
    {
        var wrapperGameObject = new GameObject("copyObject", typeof(CopyToClipboard));
        copyObject = wrapperGameObject.GetComponent<CopyToClipboard>();
    }


    public static void Copy(string textToCopy)
    {
        BrowserCopyToClipboard(textToCopy);
    }

    public static void Paste(Action<string> callback)
    {
        BrowserPasteToClipboard("copyObject", "RequestCallback");
        pathCallback = callback;
    }

    public static void SetResult(string text)
    {
        pathCallback.Invoke(text);
    }

    // Below we declare external functions from our .jslib file
    [DllImport("__Internal")]
    private static extern void BrowserCopyToClipboard(string textToCopy);

    [DllImport("__Internal")]
    private static extern string BrowserPasteToClipboard(string objectName, string methodName);
}


