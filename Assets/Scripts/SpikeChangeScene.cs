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

    public void PetrolStationScene()
    {
        SceneManager.LoadScene("PetrolStationScene");
    }

    public void SpikeMenuScene()
    {
        SceneManager.LoadScene("SpikeMenu");
    }

}
