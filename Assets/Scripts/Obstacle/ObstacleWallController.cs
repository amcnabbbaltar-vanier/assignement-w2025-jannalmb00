using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleWallController : MonoBehaviour
{
    public float upSpeed = 5f;
    public float downSpeed = 1f;
    public float maxHeight = 1f;
    public float minHeight =-1.4f;
    
    public bool isMovingUp = true;
    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
      float randomStartDelay = Random.Range(0f, 2f);
       StartCoroutine(StartWithDelay(randomStartDelay));
       
    }
    IEnumerator StartWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(MoveWall());
    }

    // Update is called once per frame
     IEnumerator MoveWall()
    {
        while (true)
        {
            if (!isPaused)
            {
                if (isMovingUp)
                {
                    transform.Translate(Vector3.up * upSpeed * Time.deltaTime);
                    if (transform.position.y >= maxHeight)
                    {
                        isMovingUp = false;
                        StartCoroutine(PauseBeforeSwitch());
                    }
                }
                else
                {
                    transform.Translate(Vector3.down * downSpeed * Time.deltaTime);
                    if (transform.position.y <= minHeight)
                    {
                        isMovingUp = true;
                        StartCoroutine(PauseBeforeSwitch());
                    }
                }
            }
            yield return null;
        }
    }

    IEnumerator PauseBeforeSwitch()
    {
        isPaused = true;
        float pauseTime = Random.Range(0.5f, 2f); // Random delay between 0.5s to 2s
        yield return new WaitForSeconds(pauseTime);
        isPaused = false;
    }
    
}
