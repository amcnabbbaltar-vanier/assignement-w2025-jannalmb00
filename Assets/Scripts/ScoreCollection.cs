using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCollection : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "ScorePickup")
        {
            score += 50;
            //ScoreText.text = "Score: " + score.ToString();
            Debug.Log("" + score);
            Destroy(other.gameObject);
        }

    }
}
