using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] int hitScore = 80;
    [SerializeField] ParticleSystem hitEffect;
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
       if(other.tag == "Enemy")
       {
           FindObjectOfType<ScoreUpdater>().AddToHitScore(hitScore);
       } 
       hitEffect.Play();
       Destroy(gameObject);
    }

    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     Destroy(gameObject);
    // }
}
