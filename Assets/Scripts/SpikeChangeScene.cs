using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeChangeScene : MonoBehaviour
{
    public void SaveDataScene()
    {
        SceneManager.LoadScene("SaveScene");
    }

    public void GizmoScene()
    {
        SceneManager.LoadScene("GizmosScene");
    }

    public void SpikeMenuScene()
    {
        SceneManager.LoadScene("SpikeMenu");
    }
}
