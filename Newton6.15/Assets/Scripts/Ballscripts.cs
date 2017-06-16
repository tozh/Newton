using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;
using UnityEditor.Sprites;
using System;

public class Ballscripts : MonoBehaviour {
	// Designer variables
	Rigidbody2D rbody2D;
	public Transform ball_position;

	public GameObject Blackpanel2;//
	public Rigidbody2D rigidball;
	public GameObject ButtonPanel;//
	public Transform crow_position;//
	public Transform snow_position;

	public Vector2 speed = new Vector2(5, 5);

	public Vector2 direction = new Vector2(1, 1);
	public int num = 0;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public int count = 0;
    private Vector2 movement;
	public bool fail = false;


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
		if (Math.Abs (ball_position.position.y - crow_position.position.y) <= 2 && Math.Abs (ball_position.position.x - crow_position.position.x) <= 2) {
			ball_position.position = crow_position.position;
		}
//		Debug.Log ("y" + ball_position.position.y);
//		Debug.Log ("Vx" + rigidball.velocity.x);
//		Debug.Log ("Vy" + rigidball.velocity.y);

		if (!fail && (snow_position.position.y - ball_position.position.y) <= 1 && Math.Abs(snow_position.position.x - ball_position.position.x) <= 1) {
			//Debug.Log ("aaaa");
			fail = true;
			Destroy (gameObject, 2);

			ButtonPanel.gameObject.SetActive (false);//
			Blackpanel2.gameObject.SetActive (true);//

		}


		if (!fail && ball_position.position.y < -10 && Math.Abs(rigidball.velocity.x) < 0.5 && Math.Abs(rigidball.velocity.y)<= 0.01 || !fail && Math.Abs(ball_position.position.x)>7.5) {
			fail = true;
			Destroy (gameObject, 2);

			ButtonPanel.gameObject.SetActive (false);//
			Blackpanel2.gameObject.SetActive (true);//
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

}
