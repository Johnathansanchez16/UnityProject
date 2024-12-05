using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu; // Reference to the settings menu GameObject
    [SerializeField] private Button settingsButton;  // Reference to the settings button
    [SerializeField] private Button resumeButton;    // Reference to the resume button

    private void Start()
    {
        // Ensure the settings menu is hidden at the start
        settingsMenu.SetActive(false);

        // Add listeners to the buttons
        settingsButton.onClick.AddListener(OpenSettings);
        resumeButton.onClick.AddListener(CloseSettings);
    }

    // Show the settings menu
    private void OpenSettings()
    {
        settingsMenu.SetActive(true);
    }

    // Hide the settings menu
    private void CloseSettings()
    {
        settingsMenu.SetActive(false);
    }
}