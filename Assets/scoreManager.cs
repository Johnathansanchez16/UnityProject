using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import the TextMesh Pro namespace

public class scoreManager : MonoBehaviour
{
    public static int score = 0; // Initial score
    public TextMeshProUGUI scoreTextTMP; // TextMesh Pro component for score display

    void Start()
    {
        UpdateScoreUI(); // Initialize score display
    }

    public void AddScore(int points)
    {
        score += points; // Increase score
        UpdateScoreUI(); // Update UI display
    }

    void UpdateScoreUI()
    {
        if (scoreTextTMP != null)
        {
            scoreTextTMP.text = "Score: " + score; // Update the TextMesh Pro text
            Debug.Log("Score Updated: " + scoreTextTMP.text); // Debug log to see if this is being called
        }
        else
        {
            Debug.LogError("scoreTextTMP is not assigned!"); // Log error if the Text component is not assigned
        }
    }
    public int getScore(){
        return score;
    }
}