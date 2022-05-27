using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEnemyButTargetP : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float runAwaySpeed = 3f;
    [SerializeField] AudioClip changeToZombieSFX;
    [SerializeField] int changeToZombieScoreValue = 100;
    [SerializeField] ParticleSystem changeToZombieEffect;

    
    public bool isActive = true;
    bool wasChangedToZombie = false;
    float runAwayDistance = 4f;

    GameObject player;
    Animator myAnimator;
    Rigidbody2D myRigidbody;
    

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>(); 
        player = GameObject.FindWithTag("Player");
    }

   
    void FixedUpdate()
    {
        
        if(!isActive) {return;}

        FlipEnemyFacing();
                
        if((transform.position - player.transform.position).magnitude >= runAwayDistance)
        {
            myRigidbody.velocity = new Vector2 (-moveSpeed,0);
        }
        else
        {
            myRigidbody.velocity = new Vector2 (runAwaySpeed,0);
        }
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
           StartCoroutine(Die());
           FindObjectOfType<GameSessions>().AddToScore(changeToZombieScoreValue);
       } 
    }

    IEnumerator Die()
    {
        isActive = false;
        myAnimator.SetBool("IsRunning", false);
        myAnimator.SetTrigger("Dead"); 
        
        AudioSource.PlayClipAtPoint(changeToZombieSFX, Camera.main.transform.position);
        changeToZombieEffect.Play();

        yield return new WaitForSecondsRealtime(1);

        Destroy(gameObject);
    }

       
}
