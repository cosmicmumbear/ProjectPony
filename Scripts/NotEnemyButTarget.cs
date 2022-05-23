using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEnemyButTarget : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.1f;
    [SerializeField] float runAwaySpeed = 0.9f;
    [SerializeField] AudioClip changeToZombieSFX;
    [SerializeField] int changeToZombieScoreValue = 100;
    Rigidbody2D myRigidbody;
    bool wasChangedToZombie = false;
    float runAwayDistance = 4.5f;
    GameObject player;

    void Awake()
    {
       myRigidbody = GetComponent<Rigidbody2D>(); 
       player = GameObject.FindWithTag("Player");
    }

   
    void Update()
    {
        if((transform.position-player.transform.position).magnitude > runAwayDistance)
        {
            myRigidbody.velocity = new Vector2 (-moveSpeed,0);
        }
        else
        {
            transform.localScale = new Vector2 ((Mathf.Sign(player.GetComponent<Rigidbody2D>().velocity.x)), 1f);
            myRigidbody.velocity = new Vector2 (runAwaySpeed,0);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        //moveSpeed = -moveSpeed;
        FlipEnemyFacing();
    }
    
    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2 ((Mathf.Sign(-myRigidbody.velocity.x)), 1f);
    }
  

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Player" && !wasChangedToZombie)
       {
           wasChangedToZombie= true;
           //AudioSource.PlayClipAtPoint( changeToZombieSFX, Camera.main.transform.position);
           Destroy(gameObject);
           FindObjectOfType<GameSessions>().AddToScore(changeToZombieScoreValue);
       } 
    }

       
}
