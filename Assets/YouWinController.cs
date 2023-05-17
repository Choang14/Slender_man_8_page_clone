using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class YouWinController : MonoBehaviour
{
    public Button retryButton;
    public Button menuButton;

    private void Start()
    {
        retryButton.onClick.AddListener(RetryGame);
        menuButton.onClick.AddListener(ReturnToMainMenu);
    }

    private void RetryGame()
    {
        SceneManager.LoadScene("Main Scene");
    }

    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

