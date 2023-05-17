using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class YouWinController : MonoBehaviour
{
    public Button retryButton;
    public Button menuButton;

    private void OnEnable()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

public void RetryGame()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

