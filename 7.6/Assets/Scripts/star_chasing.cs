using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class star_chasing : MonoBehaviour {

	public Ballscripts Ball;
	public GameObject apple;

	private Vector3 star_position;
	private bool is_chasing;
	private Vector3 ball_position;
	private double distance;
	private Vector3 star_speed;
	private float time_charge;
	private Vector3 star_moving;

	// Use this for initialization
	void Start () {
		is_chasing = false;
		star_position = transform.position;

	}

	// Update is called once per frame
	void FixedUpdate () {
		ball_position = apple.transform.position;
		distance = Math.Pow((ball_position.x - star_position.x), 2) + Math.Pow((ball_position.y - star_position.y), 2);
		//Debug.Log(Ball.is_charge);
		//Debug.Log(is_chasing);
		//Debug.Log(distance);
		if (Ball.is_charge == true && is_chasing == false && distance <= 30 && ball_position.x>= star_position.x)
		{
			is_chasing = true;
			time_charge = (Ball.end_point.x - apple.transform.position.x) / 30;
			star_speed = new Vector3((Ball.end_point.x - star_position.x) / time_charge, (Ball.end_point.y - star_position.y) / time_charge, 0);
			Debug.Log("chasing!!!");
		}
		if(is_chasing == true)
		{
			GetComponent<Rigidbody2D>().velocity = star_speed;
		} 

	}
}