/*
 * Ian Connors
 * Assignment 6 (OOP Prototype)
 * sets up references used in child spawn manager classes
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSpawnManager : MonoBehaviour
{
    protected Vector3 spawnPos = new Vector3(-11.5f, -3.1f, -3);
    [SerializeField] protected GameObject centaurPrefab;
    [SerializeField] protected GameObject harpiePrefab;
    protected GameManager gameManager;
    public int enemiesLeftToSpawn;
	// Start is called before the first frame update
	private void Awake()
	{
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManager.spawnManagerRef();
        gameManager.enemiesLeft = enemiesLeftToSpawn;
    }
	protected virtual void Start()
    {
        gameManager.statusTextObj.SetActive(true);
        GameManager.score = 0;
        gameManager.SetStatusText();
        StartCoroutine(Spawn());
    }
    protected abstract IEnumerator Spawn();
}
