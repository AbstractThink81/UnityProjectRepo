
/*
 * Ian Connors
 * Prototype 3
 * Controls player jumping, death, and collisions
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public ForceMode forceMode;
    public float gravityModifier;
    private Animator playerAnimator;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource playerAudio;
    
    public bool isOnGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {

        //set reference to rigidbody component
        rb = GetComponent<Rigidbody>();
        forceMode = ForceMode.Impulse;

        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetFloat("Speed_f", 1.0f);

        //audio source
        playerAudio = GetComponent<AudioSource>();


        //modify gravity
        if (Physics.gravity.y > -10)
		{
            Physics.gravity = new Vector3(0, -27f, 0);
		}

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
		{
            rb.AddForce(Vector3.up * jumpForce, forceMode);
            isOnGround = false;

            //set jump trigger in animator
            playerAnimator.SetTrigger("Jump_trig");

            //stop dirt particle
            dirtParticle.Stop();

            //play jump sound effect
            playerAudio.PlayOneShot(jumpSound, 1.0f);
		}
    }
	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.CompareTag("Ground"))
		{
            isOnGround = true;

            //start dirt particle again
            dirtParticle.Play();
		}
            


        else if (collision.gameObject.CompareTag("Obstacle"))
		{
            Debug.Log("Game Over");
            gameOver = true;

            //play death animation
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);

            //play explosion particle effect
            explosionParticle.Play();

            //stop dirt particle
            dirtParticle.Stop();

            //play crash sound effect
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
	}
}
