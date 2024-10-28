using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beamMovement : MonoBehaviour
{
    public float lifetime = 2f;
    private AudioSource shootingAudio;
    public AudioSource explosionAudio;
    // Start is called before the first frame update
    void Start()
    {
        
        shootingAudio=GetComponent<AudioSource>();
        shootingAudio.Play();
        Destroy(gameObject, lifetime);
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(explosionAudio.clip, transform.position);
        gameObject.SetActive(false);
    }
    
}
