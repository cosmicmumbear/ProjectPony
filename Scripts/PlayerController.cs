using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Collider2D feet;
    [SerializeField] Vector2 deathKick;
    [SerializeField] AudioClip deathSoundSFX;
    [SerializeField] ParticleSystem deathEffect;
    [SerializeField] ParticleSystem bulletEffect;
    [SerializeField] AudioClip bulletSFX;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;


    public bool isActive = true;

    Vector2 moveDirection;
    Vector2 rawInput;
    bool isJumping;
    Rigidbody2D rb;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider; 
    BoxCollider2D myFeetCollider;
    


    const string platformLayer = "Platform";

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        //Move the player
        rb.velocity = new Vector2(rawInput.x * moveSpeed, rb.velocity.y);

        bool playerHasHorizontalSpeed = Mathf.Abs(rawInput.x) > Mathf.Epsilon;
        myAnimator.SetBool("IsRunning",playerHasHorizontalSpeed);

        //Make the player jump
        if (isJumping)
        {
            rb.velocity += new Vector2(0f, jumpForce);
            isJumping = false;
        }

        FlipSprite();
        StartCoroutine(Die());
    }

    
    void OnMove(InputValue value)
    {
        if (!isActive) { return; }
        rawInput = value.Get<Vector2>();
    }
    
    void OnJump(InputValue value)
    {
        if (!isActive) { return; }
        if (!feet.IsTouchingLayers(LayerMask.GetMask(platformLayer))) { return; }

        isJumping = true;
    }

        void OnFire(InputValue value)
    {
        if(!isActive) {return;}
        AudioSource.PlayClipAtPoint(bulletSFX, Camera.main.transform.position);
        bulletEffect.Play();
        Instantiate(bullet, gun.position, transform.rotation);
    }

        void  FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(-rb.velocity.x), 1f);
        }
    }

    IEnumerator Die() 
    {
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            myAnimator.SetBool("IsRunning", false);
            myAnimator.SetTrigger("Dead"); 
            isActive = false; 
            deathEffect.Play();
            AudioSource.PlayClipAtPoint(deathSoundSFX, Camera.main.transform.position);
            rb.velocity = deathKick;  
            
            

            yield return new WaitForSecondsRealtime(1);

            SceneManager.LoadScene(3);
        }

    }
}
