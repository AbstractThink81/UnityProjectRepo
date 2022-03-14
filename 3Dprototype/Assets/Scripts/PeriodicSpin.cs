/*
 * Ian Connors
 * 3D Prototype with ProBuilder
 * Makes objects spin at random intervals and for random lengths of time
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicSpin : MonoBehaviour
{
    public float maxWait;
    public float minWait;
    public float maxSpin;
    public float minSpin;
    public float maxSpeed;
    public float minSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spin());
    }


    IEnumerator Spin()
	{
        yield return new WaitForSeconds(15f);
        while (true)
		{
            float spin = Random.Range(minSpin, maxSpin);

            float speed = Random.Range(minSpeed, maxSpeed);
            for (int i = 0; i < spin; i++)
			{
                transform.RotateAround(Vector3.zero, Vector3.up, speed);
                yield return new WaitForSeconds(0.01f);
                if (spin - i < 40)
				{
                    speed /= 2;
				}
                if (spin - i < 20)
                {
                    speed /= 2;
                }
                if (spin - i < 10)
                {
                    speed /= 2;
                }
            }
            float wait = Random.Range(minWait, maxWait);
            yield return new WaitForSeconds(wait);
		}
        
    }
}
