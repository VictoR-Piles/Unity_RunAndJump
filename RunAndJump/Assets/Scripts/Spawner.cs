using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject obstacelPrefab;
	public float startDelay = 2f;
	public float spawnInterval = 2f;

	private Vector3 spawnPos = new Vector3(30, 0, 0);
	private PlayerController playerControllerScript;

	void Start()
	{
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
		InvokeRepeating("SpawnObstacle", startDelay, spawnInterval);
	}

	void Update()
	{
	}

	void SpawnObstacle()
	{
		if (!playerControllerScript.getGameOver())
		{
			Instantiate(obstacelPrefab, spawnPos, obstacelPrefab.transform.rotation);
		}
	}
}