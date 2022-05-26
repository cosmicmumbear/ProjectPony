using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenPony : MonoBehaviour
{
    [SerializeField] AudioClip changeToZombieSFX;
    [SerializeField] int changeToZombieScoreValue = 400;
    [SerializeField] ParticleSystem changeToZombieEffect;

    
    public bool isActive = true;
    bool wasChangedToZombie = false;
   
    GameObject player;
    Animator myAnimator;
    Rigidbody2D myRigidbody;
    

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>(); 
        player = GameObject.FindWithTag("Player");
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
        
        //AudioSource.PlayClipAtPoint(changeToZombieSFX, Camera.main.transform.position);
        //changeToZombieEffect.Play();

        yield return new WaitForSecondsRealtime(1);

        Destroy(gameObject);
    }

       
}
