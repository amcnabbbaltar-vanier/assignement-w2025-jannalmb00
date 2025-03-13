using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingAndHovering : MonoBehaviour
{
    public float rotationSpeed = 20f; // Speed of rotation
    public float hoverSpeed = 2f;     // Speed of up and down movement
    public float hoverHeight = 0.2f;  // Height of hovering

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        
        transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime, Space.Self);

        
        float newY = startPosition.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
