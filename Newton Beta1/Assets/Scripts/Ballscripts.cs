﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballscripts : MonoBehaviour {
	// Designer variables
	Rigidbody2D rbody2D;
	public Vector2 speed = new Vector2(5, 5);

	public Vector2 direction = new Vector2(1, 1);
	public int num = 0;
	private Vector2 movement;


	void Start(){
			
		movement = new Vector2 (
		speed.x * direction.x,
		speed.y * direction.y);
		
		// Apply movement to the rigidbody
		rbody2D = GetComponent<Rigidbody2D> ();


	}

	public void setNum(int n) {
		this.num = n;
	}
	public void Update() {
		if (num > 0) {
			rbody2D.velocity = movement;
			num--;
		}
	}





	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "star") 
		{
			Destroy (other.gameObject);
		}
	}
		
}
