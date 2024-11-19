using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttons : MonoBehaviour
{
    public Button start;
    public Button instructions;
    public Button leaderboard;
    // Start is called before the first frame update
    void Start()
    {
        start.onClick.AddListener(() => SceneManager.LoadSceneAsync("level01") );// on click the first level will be generated
        instructions.onClick.AddListener(LoadInstructions);
        leaderboard.onClick.AddListener(LoadLeaderboard);
    }

    private void LoadInstructions(){
        SceneManager.LoadSceneAsync("instructions");
    }
    private void LoadLeaderboard(){
        SceneManager.LoadSceneAsync("leaderboard");
    }
}
