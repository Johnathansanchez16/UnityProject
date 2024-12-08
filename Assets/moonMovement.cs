using System.Collections;
using UnityEngine;

public class moonMovement : MonoBehaviour
{
    // Moon properties
    [SerializeField] float moveX = 1, moveY = 1, maxSize = 2, growthSpeed = .3f;
    [SerializeField] bool isTeleportingMoon = false;
    [SerializeField] int moonStrength = 2, SPEED = 2;
    [SerializeField] Rigidbody2D rigid;
    private float scaleInterval = 2f;

    private scoreManager scoreManager;
    private LevelManager levelManager;

    void Start()
    {
        rigid = rigid ?? GetComponent<Rigidbody2D>();
        scoreManager = FindObjectOfType<scoreManager>();
        Debug.Log(scoreManager == null ? "ScoreManager not found!" : "ScoreManager assigned.");

        levelManager = FindObjectOfType<LevelManager>();
        Debug.Log(levelManager == null ? "LevelManager not found!" : "LevelManager assigned.");
        
        InvokeRepeating(nameof(IncreaseSize), scaleInterval, scaleInterval);
        
        if (isTeleportingMoon)
            InvokeRepeating(nameof(Teleport), scaleInterval, scaleInterval);
    }

    void Update()
    {
        // Move moon and check boundaries
        rigid.velocity = new Vector2(SPEED * moveX, SPEED * moveY);
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPosition.x < 0){
            moveX = Mathf.Abs(moveX);  // Move right
        }
        else if (viewportPosition.x > 1){
            moveX = -Mathf.Abs(moveX); // Move left
        } 
        if (viewportPosition.y < 0){
            moveY = Mathf.Abs(moveY);   // Move up
        }
        else if (viewportPosition.y > 1){
            moveY = -Mathf.Abs(moveY);  // Move down
        }
        // Check for moon reaching max size
        if (transform.localScale.x > maxSize)
        {
            Debug.Log("Max size reached!!!");
            levelManager.missedMoon();
            Destroy(gameObject);
        }
    }

    void IncreaseSize() => transform.localScale += new Vector3(growthSpeed, growthSpeed, 0);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "blue-beam(Clone)")
        {
            moonStrength--;
            if (scoreManager != null)
            {
                int points = transform.localScale.x > 1 ? 1 : 2;
                scoreManager.AddScore(points);
            }

            if (moonStrength < 0)
            {
                levelManager.MoonPopped(); // Update LevelManager when a moon is popped
                Destroy(gameObject);
            }
        }
    }

    void Teleport()
    {
    Vector3 randomPosition = Camera.main.ViewportToWorldPoint(
        new Vector3(Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f), 0)
    );
    randomPosition.z = transform.position.z;
    transform.position = randomPosition;
    }
}