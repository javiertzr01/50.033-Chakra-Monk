using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Horizontal Movement
    private float speed = 20.0f;
    private float maxSpeed = 130.0f;
    private bool moving = false;
    public BoolVariable facingRight;

    // Vertical Movement
    private float jumpPower = 12.5f;
    private bool canJump = true;
    private bool jumpHigher = false;

    // Attack
    public bool attack = false;

    // Audio
    private AudioSource playerAudio;
    public AudioClip JumpSound;
    public AudioClip PunchShound;
    public AudioClip KickSound;
    public AudioClip PunchPowerSound;
    public AudioClip KickPowerSound;
    public AudioClip RunningSound;

    // Components
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        rb = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        facingRight.value = true;
        animator = gameObject.GetComponent<Animator>();
        playerAudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }

    // FixedUpdate is used for Physics Logic
    void FixedUpdate()
    {
        if (moving && !attack)
        {
            Accelerate(facingRight.value == true ? 1 : -1);
        }
        if (jumpHigher)
        {
            rb.AddForce(Vector2.up * 7.5f * jumpPower, ForceMode2D.Force);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == 3)
        {
            canJump = true;
            animator.SetBool("grounded", true);
        }
    }

    private void Accelerate (int value)
    {
        Vector2 movement = new Vector2(value, 0);
        if (rb.velocity.magnitude < maxSpeed)
        {
                rb.AddForce(movement * speed, ForceMode2D.Force);
        }
    }

    public void playRunningSound()
    {
        playerAudio.PlayOneShot(RunningSound);
    }

    public void SetMoving(int value)
    {
        if (value == 0)
        {
            moving = false;
        }
        else
        {
            // Check Direction
            FaceDirection(value);
            moving = true;
        }
    }

    private void FaceDirection(int value)
    {
        if (value == -1 && facingRight.value)
        {
            // Player
            facingRight.value = false;
            sprite.flipX = true;
            

        }
        else if (value == 1 && !facingRight.value)
        {
            // Player
            facingRight.value = true;
            sprite.flipX = false;
        }
    }

    public void Jump()
    {
        if (!attack && canJump)
        {
            rb.AddForce(Vector2.up * jumpPower , ForceMode2D.Impulse);
            canJump = false;
            jumpHigher = true;
            animator.SetBool("grounded", false);
            playerAudio.PlayOneShot(JumpSound);
        }
    }

    public void JumpStop()
    {
        jumpHigher = false;
    }

    public void Punch()
    {
        attack = true;
        animator.SetBool("punch", true);
        playerAudio.PlayOneShot(PunchShound);
    }

    public void Kick()
    {
        attack = true;
        animator.SetBool("kick", true);
        playerAudio.PlayOneShot(KickSound);
    }

    public void EndAttack()
    {
        attack = false;
        animator.SetBool("punch", false);
        animator.SetBool("kick", false);
        animator.SetBool("punch_power", false);
        animator.SetBool("kick_power", false);
    }

    public void PunchPower()
    {
        Debug.Log("Activated");
        attack = true;
        animator.SetBool("punch_power", true);
        playerAudio.PlayOneShot(PunchPowerSound);
    }
    
    public void KickPower()
    {
        attack = true;
        animator.SetBool("kick_power", true);
        playerAudio.PlayOneShot(KickPowerSound);
    }

}
