using UnityEngine;
using UnityEngine.SceneManagement;

public class DiedPanelButtonScript : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
