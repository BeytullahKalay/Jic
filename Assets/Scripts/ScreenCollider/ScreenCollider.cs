using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCollider : MonoBehaviour
{
    public GameObject leftBlock;
    public GameObject rightBlock;
    public GameObject topBlock;

    Vector3 leftBlockPos;
    Vector3 rightBlockPos;
    Vector3 topBlockPos;

    private void Start()
    {
        Vector3 topOfViewPos = new Vector3(0, 1, 0);
        Vector3 bottomOfViewPos = new Vector3(0, 0, 0);
        Vector3 topMinusBottom = Camera.main.ViewportToWorldPoint(topOfViewPos) - Camera.main.ViewportToWorldPoint(bottomOfViewPos);
        leftBlock.transform.localScale = Vector2.one * new Vector2(topMinusBottom.y * 3, 1);
        rightBlock.transform.localScale = Vector2.one * new Vector2(topMinusBottom.y * 3, 1);

        leftBlockPos = new Vector3(0, 0, 0);
        rightBlockPos = new Vector3(1, 0, 0);

        leftBlockPos = Camera.main.ViewportToWorldPoint(leftBlockPos);
        rightBlockPos = Camera.main.ViewportToWorldPoint(rightBlockPos);

        leftBlockPos.x -= leftBlock.transform.localScale.y / 2;
        rightBlockPos.x += rightBlock.transform.localScale.y / 2;


        Vector3 leftOfViewPos = new Vector3(0, 0, 0);
        Vector3 rightOfViewPos = new Vector3(1, 0, 0);
        Vector3 leftMinusRight = Camera.main.ViewportToWorldPoint(leftOfViewPos) - Camera.main.ViewportToWorldPoint(rightOfViewPos);
        topBlock.transform.localScale = Vector2.one * new Vector2(1, leftMinusRight.x * 3);

        topBlockPos = new Vector3(0.5f, 1, 0);

        topBlockPos = Camera.main.ViewportToWorldPoint(topBlockPos);

        topBlockPos.y += topBlock.transform.localScale.x;

    }


    private void Update()
    {
        Vector2 viewPos = Camera.main.transform.position;
        leftBlockPos.y = rightBlockPos.y = viewPos.y;

        leftBlock.transform.position = leftBlockPos;
        rightBlock.transform.position = rightBlockPos;

        float top = topBlockPos.y + viewPos.y;
        topBlock.transform.position = new Vector3(topBlockPos.x, top, topBlockPos.z);
    }
}
