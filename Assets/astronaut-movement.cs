using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float moveX;
    [SerializeField] float moveY;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] const int SPEED = 10;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] GameObject laserPrefab; // Drag your laser prefab here in the Unity editor
    [SerializeField] Transform firePoint;    // Assign a point in front of your player where the laser will spawn
    [SerializeField] float laserSpeed = 12f;
    // Start is called before the first frame update

    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        if(Input.GetButtonDown("Fire1"))
        {
            FireLaser();
        }
    }
    private void FixedUpdate(){
        rigid.velocity=new Vector2(SPEED*moveX,SPEED*moveY);
        if (moveX < 0 && isFacingRight || moveX > 0 && !isFacingRight)
            Flip();
        
    }
    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
    void FireLaser(){
        GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        float direction = isFacingRight ? 1f : -1f;
        rb.velocity = new Vector2(direction * laserSpeed, 0f);
    }

}
