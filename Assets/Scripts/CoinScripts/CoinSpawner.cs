using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public Vector2 secondsBetweenSpawnsMinMax;


    Camera cam;

    Vector2 screenHalfSizeWorldUnits;

    float nextSpawnTime;


    void Start()
    {
        cam = Camera.main;

        CalculateWorldUnits();
    }



    void Update()
    {

        float camPosY = cam.transform.position.y + screenHalfSizeWorldUnits.y;
        if (Time.time > nextSpawnTime)
        {
            float getRandomSpawnTime = Random.Range(secondsBetweenSpawnsMinMax.x, secondsBetweenSpawnsMinMax.y);
            nextSpawnTime = Time.time + getRandomSpawnTime;

            Vector2 spawnerPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), camPosY);
            Instantiate(coinPrefab, spawnerPosition, coinPrefab.transform.rotation);
        }

    }

    private void CalculateWorldUnits()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }
}
