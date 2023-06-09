﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] private float jumpForce = 100f;
    [SerializeField] private AudioClip sfxJump ;
    [SerializeField] private AudioClip sfxDeath;



	private Animator anim;
	private Rigidbody rigidBody;
	private bool jump = false;
    private AudioSource audioSource;

	


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody> ();
        audioSource = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {


        if(!GameManager.instance.GameOver && GameManager.instance.GameStarted){
		if (Input.GetMouseButtonDown (0)) {
			GameManager.instance.PlayerStartedGame ();
			anim.Play ("Jump");
               audioSource.PlayOneShot(sfxJump);
	        rigidBody.useGravity = true;
			jump = true;
			}
		}
			
	}

	void FixedUpdate(){

		if (jump == true) {
			jump = false;
			rigidBody.velocity = new Vector2 (0, 0);
			rigidBody.AddForce (new Vector2 (0, jumpForce), ForceMode.Impulse);
		
		}
			

	}

	void OnCollisionEnter (Collision Collision){
		if (Collision.gameObject.tag == "obstacle") {
			rigidBody.AddForce (new Vector2 (-50,20), ForceMode.Impulse);
			rigidBody.detectCollisions = false;
            audioSource.PlayOneShot(sfxDeath);
			GameManager.instance.PlayerCollided ();
		}
		
	}
		

}

