using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    Camera cam;
    Vector2 screenHalfSizeWorldUnits;
    void Start()
    {
        CalculateWorldUnits();
        cam = FindObjectOfType<Camera>();
    }

    private void Update()
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

        if (transform.position.y + (transform.localScale.y/2) < destroyPos)
        {
            Destroy(gameObject);
        }
    }
}
