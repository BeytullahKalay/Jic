using UnityEngine;
using TMPro;
public class PlayerDead : MonoBehaviour
{
    public GameObject deadScreen;
    public TextMeshProUGUI secondsSurvivedUI;


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
        Destroy(gameObject);
    }
}
