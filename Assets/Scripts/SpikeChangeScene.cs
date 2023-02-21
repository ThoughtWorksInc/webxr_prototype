using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeChangeScene : MonoBehaviour
{
    public void SpikeMenuScene()
    {
        SceneManager.LoadScene("SpikeMenu");
    }

    public void Week1Scene()
    {
        SceneManager.LoadScene("TrainerScene");
    }

    public void ApiRequestScene()
    {
        SceneManager.LoadScene("ApiScene");
    }
}
