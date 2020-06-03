using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
	private PlayerController playerControllerScript;

	public float speed = 30f;

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
		else
		{
			playerControllerScript.jumpForce = 0;
		}
	}
}