using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuButton : MonoBehaviour
{
    public Button menubutton;
    // Start is called before the first frame update
    void Start()
{
    menubutton.onClick.AddListener(goToMenu);
}

    // Update is called once per frame
    private void goToMenu()
    {
        SceneManager.LoadSceneAsync("Game");
    }
}
