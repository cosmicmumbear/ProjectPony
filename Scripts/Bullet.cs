using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] int hitScore = 80;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] AudioClip hitSFX;
    Rigidbody2D myRigidbody;
    PlayerController player;
    float xSpeed;

    void Start()
    {
       myRigidbody = GetComponent<Rigidbody2D>(); 
       player = FindObjectOfType<PlayerController>();
       xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
         myRigidbody.velocity = new Vector2 (-xSpeed,0f);
    }

   void OnTriggerEnter2D(Collider2D other)
    {
       hitEffect.Play();
       AudioSource.PlayClipAtPoint(hitSFX, Camera.main.transform.position);
       if(other.tag == "Enemy")
       {
           FindObjectOfType<ScoreUpdater>().AddToHitScore(hitScore);
       } 
       Destroy(gameObject);
    }

    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     Destroy(gameObject);
    // }
}
