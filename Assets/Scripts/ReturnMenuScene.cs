using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenuScene : MonoBehaviour
{
    public void ReturnMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
