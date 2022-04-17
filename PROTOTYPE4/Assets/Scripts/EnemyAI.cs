/*
 * Ian Connors
 * Prototype 4
 * Makes enemies move toward player
 */
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject player;
    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        rb.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
		{
            Destroy(gameObject);
		}
    }
}
