using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton:GameManager
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    public AudioSource menuMusic;
    public AudioSource gameOverMusic;
    private void Start()
    {
        menuMusic.Play();
    }

}
