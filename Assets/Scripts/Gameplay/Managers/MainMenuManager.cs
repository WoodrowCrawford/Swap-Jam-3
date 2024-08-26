using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Button playButton;

    private void OnEnable()
    {
        playButton.onClick.AddListener(() => SceneManager.LoadScene(1));
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveListener(() => SceneManager.LoadScene(1));
    }
}
