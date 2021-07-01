using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Power Values")]
    public float power = 10;
    public float maxDrag = 5;


    Rigidbody2D rb;
    LineRenderer lr;

    Vector3 dragStartPos;
    Vector3 draggingPos;
    Vector3 dragStartViewPos;
    Touch touch;

    [Header("Power Shower Values")]
    public GameObject point;
    public int numberOfPoints;
    public float spaceBetweenPoints;

    GameObject[] points;
    Vector3 clampedForce;
    Vector3 dragReleasePos;
    Vector2 drawerDirection;
    float finalForce;

    [Header("Falling Gravity Values")]
    [SerializeField] float fallMultiplier = 2.5f;

    bool canJump;
    bool touchStarted;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();

        points = new GameObject[numberOfPoints];
    }

    private void Update()
    {
        if (Input.touchCount > 0 && canJump)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                DragStart();
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Dragging();
            }

            if (touch.phase == TouchPhase.Stationary)
            {
                Stationary();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                DragRelease();
            }
        }

        TryToDrawnDirectionShower();
        SetGravityWhileFalling();
    }



    void DragStart()
    {
        touchStarted = true;
        dragStartPos = Camera.main.ScreenToWorldPoint(touch.position);
        dragStartPos.z = 0;
        lr.positionCount = 1;
        lr.SetPosition(0, dragStartPos);

        dragStartViewPos = Camera.main.WorldToViewportPoint(dragStartPos);

        SpawnDirectionShower();

    }

    void Dragging()
    {
        DraggingAndStationary();
    }



    void Stationary()
    {
        DraggingAndStationary();
    }

    void DragRelease()
    {
        if (touchStarted)
        {
            lr.positionCount = 0;
            dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
            dragReleasePos.z = 0;

            Vector3 force = dragStartPos - dragReleasePos;
            clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

            rb.AddForce(clampedForce, ForceMode2D.Impulse);

            dragStartPos = Vector3.zero;
            draggingPos = Vector3.zero;
            dragReleasePos = Vector3.zero;

            DeleteDirectionShower();

            canJump = false;
            touchStarted = false;
        }
    }

    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)transform.position + (-drawerDirection.normalized * finalForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }

    private void DraggingAndStationary()
    {
        if (touchStarted)
        {
            draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
            draggingPos.z = 0;

            lr.positionCount = 2;
            lr.SetPosition(0, Camera.main.ViewportToWorldPoint(dragStartViewPos));
            lr.SetPosition(1, draggingPos);

            dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
            dragReleasePos.z = 0;

            dragStartPos = Camera.main.ViewportToWorldPoint(dragStartViewPos);

            Vector3 force = dragStartPos - dragReleasePos;
            clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;
            drawerDirection = dragReleasePos - dragStartPos;

            Vector2 currentVelocity = rb.velocity;
            float currentForce = Mathf.Sqrt(Mathf.Pow(currentVelocity.x, 2) + Mathf.Pow(currentVelocity.y, 2));
            float launchForce = Mathf.Sqrt(Mathf.Pow(clampedForce.x, 2) + Mathf.Pow(clampedForce.y, 2));
            finalForce = launchForce - currentForce;
        }
    }

    void SpawnDirectionShower()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, transform.position, Quaternion.identity);
        }
    }

    void DeleteDirectionShower()
    {
        if (numberOfPoints > 0)
        {
            for (int i = 0; i < numberOfPoints; i++)
            {
                Destroy(points[i]);
            }
        }

    }

    private void TryToDrawnDirectionShower()
    {
        if (points[0] != null)
        {
            for (int i = 0; i < numberOfPoints; i++)
            {
                points[i].transform.position = PointPosition(i * spaceBetweenPoints);
            }
        }
    }

    private void SetGravityWhileFalling()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == 9) // static layer
        {
            canJump = true;
        }
    }

    public void GetDeleteDirectinShower() // using by PlayerDead.cs for deleting line renderer
    {
        DeleteDirectionShower();
    }


}
