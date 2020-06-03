using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
	public float speed = 30f;
	public float outOfBoundsLeftX = -15f;
	
	private PlayerController playerControllerScript;

	void Start()
	{
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
	}

	void Update()
	{
		if (!playerControllerScript.getGameOver())
		{
			transform.Translate(Vector3.left * (Time.deltaTime * speed));
		}

		if (transform.position.x <= outOfBoundsLeftX && gameObject.CompareTag("Obstacle"))
		{
			Destroy(gameObject);
		}
	}
}