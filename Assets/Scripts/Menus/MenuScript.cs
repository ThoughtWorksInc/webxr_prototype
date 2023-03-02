using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public void TrainerSceneButtonClick()
    {
        SceneManager.LoadScene("TrainerScene");
    }
    public void TraineeSceneButtonClick()
    {
        SceneManager.LoadScene("TrainingScene");
    }
}
