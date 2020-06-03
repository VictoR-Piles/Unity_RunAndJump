using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float gravityModifier = 1f;
	public float jumpForce = 10f;

	private Rigidbody rb;
	private Animator anim;
	private bool onGround = true;
	private bool gameOver = false;
	private static readonly int JumpTrig = Animator.StringToHash("Jump_trig");
	private static readonly int DeathB = Animator.StringToHash("Death_b");
	private static readonly int DeathTypeInt = Animator.StringToHash("DeathType_Int");

	void Start()
	{
		Physics.gravity *= gravityModifier;
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && onGround && !gameOver)
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			anim.SetTrigger(JumpTrig);	// TAMBIEN SE PUEDE PASAR COMO STRING
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
			anim.SetBool(DeathB, true);
		}
	}

	public bool getGameOver()
	{
		return gameOver;
	}
}