using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private string[] sceneNames; // List of scene names
    private int currentSceneIndex = 0;            // Current level index
    private int numberOfMoons;                     // Number of moons in the current level
    [SerializeField] private int[] levelMoonNumbers = { 1, 3, 6, 4, 8}; // Number of moons for each level
    public static LevelManager instance;           // Singleton instance
    private scoreManager scoreMan; // Declare without initialization
    private int score;

    void Awake()
    {
        // Singleton implementation
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object alive across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate
        }
        
        
    }

    
     
    

    private void LoadLevel(int index)
    {
        if (index < sceneNames.Length) // Ensure index is valid
        {
            numberOfMoons = levelMoonNumbers[index]; // Set moons for this level
            Debug.Log($"Loading level: {sceneNames[index]} with {numberOfMoons} moons.");

            // Start asynchronous scene loading
            var asyncOperation = SceneManager.LoadSceneAsync(sceneNames[index]);
            asyncOperation.allowSceneActivation = false; // Prevent activation until ready

            // Activate the scene when you're ready, here you might want to wait for certain conditions
            // For demonstration, we'll activate it immediately for now
            asyncOperation.allowSceneActivation = true; // Activate the scene

            GameObject scoreManagerObj = GameObject.FindWithTag("scoreManager");
            scoreMan = scoreManagerObj.GetComponent<scoreManager>();
            
        
        }
        else
        {
            Debug.Log("All levels completed!");
            // Handle completion logic if necessary (e.g., restarting or showing a game over screen)
        }
    }

    public void CompleteLevel()
    {
        if(scoreMan!=null){
            Debug.Log(scoreMan.getScore());
        }
        else{
            Debug.Log("Data not set");
        }
        
         
        currentSceneIndex++;
        
        if (currentSceneIndex < sceneNames.Length)
        {
            LoadLevel(currentSceneIndex); // Load the next level
        }
        else
        {
            SceneManager.LoadSceneAsync("end");
        }
    }

    public void MoonPopped()
    {
        numberOfMoons--;
        Debug.Log("Moon popped! Remaining moons: " + numberOfMoons);

        if (numberOfMoons <= 0) // Check if all moons are popped
        {
            Debug.Log("All moons popped, completing the level.");
            CompleteLevel(); // Move to the next level
        }
    }

    public void missedMoon()
    {
        LoadLevel(currentSceneIndex);
    }
    // public void AddScore(int score){
    //     this.score+=score;
    // }
}