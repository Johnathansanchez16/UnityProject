using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PersistentData : MonoBehaviour{

    public TMP_Dropdown difficulty;
    private int difficultyIndex;
    public Slider volumeSlider; // Reference to the slider



    private scoreManager scoreManager;

    public static PersistentData Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }

        else
            Destroy(gameObject);
    }

    void Start()
    {
        if (scoreManager != null)
        {
            scoreManager = FindObjectOfType<scoreManager>();
        }
        if (difficulty != null)
        {
            difficulty.onValueChanged.AddListener(setDifficulty);
        }

        if (volumeSlider != null)
        {
            volumeSlider.value = AudioListener.volume;
            volumeSlider.onValueChanged.AddListener(setVolume);
        }
    }

    public int getScore(){
        return scoreManager.getScore();
    }
    public int getDifficulty(){
        return difficulty.value;
    }
    public void setDifficulty(int difficulty){
        difficultyIndex=difficulty;
    }
    public void setVolume(float value)
    {
        AudioListener.volume = value; // Adjust global audio volume
        Debug.Log("Volume set to: " + value);
    }
    public float getVolume(){
        return AudioListener.volume;
    }
}
