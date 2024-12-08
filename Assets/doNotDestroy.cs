using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doNotDestroy : MonoBehaviour
{
    public static doNotDestroy Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
