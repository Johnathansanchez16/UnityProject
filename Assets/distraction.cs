using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distraction : MonoBehaviour
{
    [SerializeField] float moveX = 1, moveY = 1;
    [SerializeField] int SPEED = 2;
    [SerializeField] Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = rigid ?? GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(SPEED * moveX, SPEED * moveY);
        Destroy(gameObject,10f);
    }
}
