using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] platformBlockPrefab;
    public Vector2 secondsBetweenSpawnsMinMax;
    public Vector2 spawnSizeMinMax;
    public Camera cam;

    public float spawnAngleMax;

    float nextSpawnTime;
    Vector2 screenHalfSizeWorldUnits;


    void Start()
    {
        CalculateWorldUnits();
    }

    void Update()
    {
        HandleWithSpawner();
    }

    private void CalculateWorldUnits()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    private void HandleWithSpawner()
    {
        int randomPlatformPicker = Random.Range(1, platformBlockPrefab.Length);

        float camPosY = cam.transform.position.y + screenHalfSizeWorldUnits.y;
        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            Vector2 spawnerPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), camPosY);
            GameObject newPlatform = (GameObject)Instantiate(platformBlockPrefab[randomPlatformPicker], spawnerPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            newPlatform.transform.localScale = Vector2.one * spawnSize;
        }
    }
}
