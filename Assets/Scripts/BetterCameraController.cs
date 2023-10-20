using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterCameraController : MonoBehaviour
{
    private Transform player;
    public Transform startLimit;
    public Transform endLimit;
    private Vector3 startPosition;
    private float startX;
    private float endX;
    // private float startY;
    private float viewportHalfwidth;

    public float verticalOffset = .2f; // Offset in the vertical axis

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        startPosition = transform.position;

        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        viewportHalfwidth = Mathf.Abs(bottomLeft.x - this.transform.position.x);
        startX = startLimit.transform.position.x + viewportHalfwidth;
        endX = endLimit.transform.position.x - viewportHalfwidth;
    }

    void Update()
    {
        float desiredX = player.position.x;
        float desiredY = player.position.y;

        if (desiredX > startX && desiredX < endX)
        {
            this.transform.position = new Vector3(desiredX, desiredY, this.transform.position.z);
        }
        else
        {
            this.transform.position = new Vector3(transform.position.x, desiredY, this.transform.position.z);
        }
    }

    public void GameRestart()
    {
        transform.position = startPosition;
    }
}
