
/*
 * Ian Connors
 * Challenge 3
 * Controls player movement
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public UIManager uIManager;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bipSound;


    // Start is called before the first frame update
    void Start()
    {
        if (Physics.gravity.y > -10f)
            Physics.gravity *= gravityModifier;

        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
        if (transform.position.y < 1)
		{
            playerRb.AddForce(Vector3.up * floatForce);
            playerAudio.PlayOneShot(bipSound, 1.0f);
        }
        if (transform.position.y > 15)
		{
            transform.position = new Vector3(transform.position.x, 15, transform.position.z);
		}
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            uIManager.AddScore(1);
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}
