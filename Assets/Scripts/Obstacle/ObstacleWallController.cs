using System.Collections;
using UnityEngine;

public class ObstacleWallController : MonoBehaviour
{
    public float upSpeed = 5f;
    public float downSpeed = 1f;
    public float hoverHeight = 1f;  // The amount it moves up/down
    public bool isMovingUp = true;

    private float startY;   // Store initial Y position
    private bool isPaused = false;

    void Start()
    {
        startY = transform.position.y;  // Capture starting Y position
        float randomStartDelay = Random.Range(0f, 2f);
        StartCoroutine(StartWithDelay(randomStartDelay));
    }

    IEnumerator StartWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(MoveWall());
    }

    IEnumerator MoveWall()
    {
        while (true)
        {
            if (!isPaused)
            {
                if (isMovingUp)
                {
                    transform.Translate(Vector3.up * upSpeed * Time.deltaTime);
                    if (transform.position.y >= startY + hoverHeight) // Relative max height
                    {
                        isMovingUp = false;
                        StartCoroutine(PauseBeforeSwitch());
                    }
                }
                else
                {
                    transform.Translate(Vector3.down * downSpeed * Time.deltaTime);
                    if (transform.position.y <= startY - hoverHeight) // Relative min height
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
        float pauseTime = Random.Range(0.5f, 2f);
        yield return new WaitForSeconds(pauseTime);
        isPaused = false;
    }
}
