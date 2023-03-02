using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OverlayOptionsMenu : MonoBehaviour
{
    public GameObject buttonTemplate;

    public Sprite text_sprite;
    public Sprite image_sprite;

    void Start()
    {
        GameObject text_button = Instantiate(buttonTemplate, transform);
        text_button.transform.GetComponent<Image>().sprite = text_sprite;
        text_button.name = "Text";

        GameObject image_button = Instantiate(buttonTemplate, transform);
        image_button.transform.GetComponent<Image>().sprite = image_sprite;
        image_button.name = "Image";

        buttonTemplate.SetActive(false);
    }
}
