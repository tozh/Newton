using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class MoveScript : MonoBehaviour
{
	// 1 - Designer variables

	/// <summary>
	/// Object speed
	/// </summary>
	public Vector2 speed = new Vector2(5, 5);

	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2(-1, 0);

	private Vector2 movement;

	void Update()
	{
		// 2 - Movement
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
	}

	void FixedUpdate()
	{
		// 5 - Move the game objectd
		Rigidbody2D rbody2D;
		rbody2D = GetComponent<Rigidbody2D>();
		rbody2D.velocity = movement;
	}
}