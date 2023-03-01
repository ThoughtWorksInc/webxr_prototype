using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public List<GameObject> panels;

    private void Start()
    {
        foreach (Transform child in this.transform)
        {
            panels.Add(child.gameObject);
        }
    }

    public void SetPanelActive(string name)
    {
        foreach(GameObject panel in panels)
        {
            if(panel.name.Equals(name)) {
                panel.SetActive(true);
            } else
            {
                panel.SetActive(false);
            }
        }
    }
}
