using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PersistentData : MonoBehaviour
{
    public TMP_Dropdown difficulty;
    private int difficultyIndex;
    public Slider volumeSlider; // Reference to the slider
    private float volumeFloat;
    private int score;

    private scoreManager scoreManager;

    public static PersistentData Instance;

    private void Awake()
    {

        // Ensure references to all necessary objects are assigned
        if (scoreManager == null)
        {
            scoreManager = FindObjectOfType<scoreManager>(); // Find the scoreManager in the scene
            if (scoreManager != null)
            {
                DontDestroyOnLoad(scoreManager.gameObject); // Prevent the scoreManager from being destroyed
            }
            else
            {
                Debug.LogError("Score Manager Not Assigned!");
            }
        }

        // Ensure the difficulty dropdown is assigned and persists
        if (difficulty != null)
        {
            difficulty.value = difficultyIndex;
            difficulty.onValueChanged.AddListener(setDifficulty);
            DontDestroyOnLoad(difficulty.gameObject); // Prevent the dropdown from being destroyed
        }

        // Ensure the volume slider is assigned and persists
        if (volumeSlider != null)
        {
            volumeSlider.value = volumeFloat;
            AudioListener.volume = volumeSlider.value;
            volumeSlider.onValueChanged.AddListener(setVolume);
            DontDestroyOnLoad(volumeSlider.gameObject); // Prevent the slider from being destroyed
        }
    }

    // Set the score
    public void setScore(int score)
    {
        this.score += score;
    }

    // Get the difficulty
    public int getDifficulty()
    {
        return difficulty.value;
    }

    // Set the difficulty
    public void setDifficulty(int difficulty)
    {
        difficultyIndex = difficulty;
        Debug.Log("Difficulty set to: " + difficultyIndex);
    }

    // Set the volume
    public void setVolume(float value)
    {
        AudioListener.volume = value; // Adjust global audio volume
        Debug.Log("Volume set to: " + value);
    }

    // Get the volume
    public float getVolume()
    {
        return AudioListener.volume;
    }
}