using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float gravityModifier = 1f;
	public float jumpForce = 10f;

	private Rigidbody rb;
	private bool onGround = true;
	private bool gameOver = false;

	void Start()
	{
		Physics.gravity *= gravityModifier;
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && onGround)
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			onGround = false;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			onGround = true;
		}
		else if (collision.gameObject.CompareTag("Obstacle"))
		{
			gameOver = true;
			Debug.Log("GAME OVER");
		}
	}
}