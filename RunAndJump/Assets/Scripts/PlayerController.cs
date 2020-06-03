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

	private void OnCollisionEnter(Collision other)
	{
		onGround = true;
	}
}