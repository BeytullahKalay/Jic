using UnityEngine;

public class CamMovement : MonoBehaviour
{

    public Vector2 speedMinMax;

    float upSpeed;

    void Start()
    {
        upSpeed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
    }

    void Update()
    {
        transform.Translate(Vector2.up * upSpeed * Time.deltaTime);
    }
}
