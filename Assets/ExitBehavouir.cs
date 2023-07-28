using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBehavouir : MonoBehaviour
{
    ScoreManager scoreManager;
    public int pointsToAdd = 10;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnMouseDown()
    {
        Debug.Log("destroyed!");
        Destroy(transform.parent.gameObject);
        if (scoreManager != null)
        {
            scoreManager.UpdateScore(pointsToAdd);
        }
    }
}
