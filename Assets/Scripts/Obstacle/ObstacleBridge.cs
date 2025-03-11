using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBridge : MonoBehaviour
{
    private int maxHeight = 1;
    private int speed = 2;
    private Vector3 startY;
    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startY + new Vector3(0, Mathf.Sin(Time.time * speed) * maxHeight, 0);
        
    }
}
