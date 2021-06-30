using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayButtonFunction()
    {
        SceneManager.LoadScene(1);
    }

    public void MarketButtonFunction()
    {
        Debug.Log("Market Button Pressed!");
    }
}
