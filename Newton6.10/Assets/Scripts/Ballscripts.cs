using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography.X509Certificates;
using System;

public class Ballscripts : MonoBehaviour {
	// Designer variables
	Rigidbody2D rbody2D;
	public Transform ball_position;
	public Transform Failure_pop_up;
	public Rigidbody2D rigidball;

	public Vector2 speed = new Vector2(5, 5);

	public Vector2 direction = new Vector2(1, 1);
	public int num = 0;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public int count = 0;
    private Vector2 movement;


	void Start(){
			
		movement = new Vector2 (
		speed.x * direction.x,
		speed.y * direction.y);
		
		// Apply movement to the rigidbody
		rbody2D = GetComponent<Rigidbody2D> ();
		rbody2D.bodyType = RigidbodyType2D.Static;

        count = 0;

        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

    }

	public void setNum(int n) {
		this.num = n;
	}
	public void Update() {
		if (num > 0) {
			rbody2D.velocity = movement;
			rbody2D.bodyType = RigidbodyType2D.Dynamic;
			num--;
		}

		if (ball_position.position.y < -10 && Math.Abs(rigidball.velocity.x) == 0 && Math.Abs(rigidball.velocity.y) == 0) {
			Destroy (gameObject, 2);
			Failure_pop_up.gameObject.SetActive (true);
		}
	}
		
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "star") 
		{
			Destroy (other.gameObject);

            count = count + 1;

            if(count == 1)
            {
                star1.SetActive(true);
            }

            if (count == 2)
            {
                star2.SetActive(true);
            }

            if (count == 3)
            {
                star3.SetActive(true);
            }
        }
	}

	/*public int showstar()
	{
		return count;
	}
	*/
		
}
