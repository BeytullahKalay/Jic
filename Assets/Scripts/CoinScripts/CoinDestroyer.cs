using UnityEngine;

public class CoinDestroyer : MonoBehaviour
{
    Camera cam;
    Vector2 screenHalfSizeWorldUnits;
    private void Start()
    {
        cam = Camera.main;
        CalculateWorldUnits();

    }
    void Update()
    {
        CalculateAndDestroy();
    }

    private void CalculateWorldUnits()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    private void CalculateAndDestroy()
    {
        float destroyPos = cam.transform.position.y - screenHalfSizeWorldUnits.y;

        if (transform.position.y + (transform.localScale.y / 2) < destroyPos)
        {
            Destroy(gameObject);
        }
    }
}
