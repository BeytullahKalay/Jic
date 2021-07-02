using UnityEngine;
using UnityEngine.SceneManagement;

public class DiedPanelButtonScript : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
