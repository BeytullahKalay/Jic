using UnityEngine;
using UnityEngine.UI;
public class PlayerDead : MonoBehaviour
{
    public CoinScritableObject Repo;
    public GameObject deadScreen;
    public Text secondsSurvivedUI;
    public Text earnedCoinsUI;
    public Text goldShowerTextUI;

    Vector2 screenHalfSizeWorldUnits;

    void Start()
    {
        CalculateWorldUnits();
        GameEvent.current.onPlayerDead += OnPlayerDead;
    }

    private void Update()
    {
        CalculatePlayerPosition();
    }

    private void CalculateWorldUnits()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    private void CalculatePlayerPosition()
    {
        float gameOverPos = Camera.main.transform.position.y - screenHalfSizeWorldUnits.y;

        if (transform.position.y + (transform.localScale.y/2) < gameOverPos)
        {
            OnPlayerDead();
        }
    }
    private void OnPlayerDead()
    {
        GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>().gameOverMusic.Play();
        GetComponent<Movement>().GetDeleteDirectinShower();
        deadScreen.SetActive(true);
        secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        earnedCoinsUI.text = ((int)Time.timeSinceLevelLoad / 2).ToString();
        Repo.IncreaseCoin((int)Time.timeSinceLevelLoad / 2);
        goldShowerTextUI.text = Repo.getCoinAsInt().ToString();

        Destroy(gameObject);
    }
}
