using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;

	[SerializeField]
	private float speed;

	void Start ()
	{

		rb = GetComponent<Rigidbody> ();

	}

	void FixedUpdate () 
	{

		float vMove = Input.GetAxis ("Vertical");
		float hMove = Input.GetAxis ("Horizontal");

		rb.AddRelativeForce (hMove * speed, 0f, vMove * speed);
	

	}


}
