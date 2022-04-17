/*
 * Ian Connors
 * Prototype 4
 * Controls player movement
 */
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private float forwardInput;
    public bool hasPowerup;

    private GameObject focalPoint;
    private float powerupStrength = 15f;

    public GameObject powerupIndicator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindGameObjectWithTag("FocalPoint");
    }

    // Update is called once per frame
    private void Update()
    {
        forwardInput = Input.GetAxis("Vertical");

        //move powerup indicator to player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
	private void FixedUpdate()
	{
        rb.AddForce(speed * forwardInput * focalPoint.transform.forward);
        if (transform.position.y < -10)
        {
            GameManager.Lose();
        }
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Powerup"))
		{
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdown());
            powerupIndicator.gameObject.SetActive(true);
		}
	}
    IEnumerator PowerupCountdown()
	{
        yield return new WaitForSeconds(7f);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (hasPowerup && collision.gameObject.CompareTag("Enemy"))
		{
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;
            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
		}
	}
}
