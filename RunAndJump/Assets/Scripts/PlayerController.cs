using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public ParticleSystem explosionParticle;
	public ParticleSystem dirtParticle;
	public AudioClip jumpSound;
	public AudioClip crashSound;
	public float gravityModifier = 1f;
	public float jumpForce = 10f;

	private Rigidbody rb;
	private Animator anim;
	private AudioSource audioSrc;
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
		audioSrc = GetComponent<AudioSource>();
		dirtParticle.Play();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && onGround && !gameOver)
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			anim.SetTrigger(JumpTrig); // TAMBIEN SE PUEDE PASAR COMO STRING
			dirtParticle.Stop();
			audioSrc.PlayOneShot(jumpSound, 1f);
			onGround = false;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			onGround = true;
			dirtParticle.Play();
		}
		else if (collision.gameObject.CompareTag("Obstacle"))
		{
			gameOver = true;
			explosionParticle.Play();
			dirtParticle.Stop();
			audioSrc.PlayOneShot(crashSound, 1f);
			anim.SetBool(DeathB, true);
		}
	}

	public bool getGameOver()
	{
		return gameOver;
	}
}