using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosePopup : MonoBehaviour
{
    // Start is called before the first frame update
    // public UnityEngine.UI.Button closeButton;

    // void Start(){
    //     Debug.Log("start of popup");
    //     // closeButton = closeButton.GetComponent<Button>();
    //     closeButton.onClick.AddListener(() => destroyPopup());
    // }

    // void update(){
    //     Debug.Log("Update popup");
    //     closeButton.onClick.AddListener(() => destroyPopup());
    // }
    public void destroyPopup()
    {
        Debug.Log("Close popup");
        Destroy(transform.parent.gameObject);
        Debug.Log("Done close popup");
    }

}
