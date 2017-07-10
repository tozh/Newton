using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;
//using UnityEditor.Sprites;
using System;

public class Ballscripts : MonoBehaviour {
	
	Rigidbody2D rbody2D;
	public Transform ball_position;
	public Transform crow_position;
	public Transform snow_position;
	public Transform snow1_position;
	public Transform snow2_position;
	public Transform snow3_position;

	public GameObject Blackpanel2;
	public GameObject ButtonPanel;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public int count = 0;
	public int num = 0;
	public int iceProtection;

	public Vector2 speed = new Vector2(5, 5);
	public Vector2 direction = new Vector2(1, 1);
	private Vector2 movement;

	public GameObject charge;
	public GameObject chargeanimation;

	private Vector3 charge_point;
	public Vector3 end_point;
	private Vector3 speed_charge = new Vector3(30,0,0);
	private Vector3 speed_normal = new Vector3(10,0,0);
	private Vector3 position;

	public bool is_charge = false;


	public bool fail = false;

	public PhysicsMaterial2D ballMaterial;

	int audiobird = 1;
	int audiosnow = 1;

	void Start(){
		// Apply movement to the rigidbody
		movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);		
		rbody2D = GetComponent<Rigidbody2D> ();
		rbody2D.bodyType = RigidbodyType2D.Static;

        count = 0;
		iceProtection = 0;

        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

		chargeanimation.SetActive (false);

		charge_point = charge.transform.position;
		end_point = charge_point;
		end_point.x = end_point.x + 20.0f;


    }

	public void setNum(int n) {
		this.num = n;
	}
	public void Update() {
		if (num > 0) {
			rbody2D.bodyType = RigidbodyType2D.Dynamic;
			rbody2D.velocity = movement;
			num--;
		}
		//get the bird

		if (Math.Abs (ball_position.position.y - crow_position.position.y) <= 1.4 && Math.Abs (ball_position.position.x - crow_position.position.x) <= 1.4) {
			//Audio
			if (audiobird == 1) {
				AudioSource Audio;
				Audio = gameObject.AddComponent<AudioSource> ();
				Audio.clip = Resources.Load ("crown") as AudioClip;
				Audio.Play ();
				audiobird = 0;
			}
			ball_position.position = crow_position.position;
			if (ball_position.position.x < 20) {
				GameFail();
			}
		}
		//left side
		if (ball_position.position.x < -23) {
			GameFail();
		}
		//right side
		if (!fail && ball_position.position.x > 104.5) {
			GameFail();
		}

		//snow
		if (Math.Abs (ball_position.position.y - snow_position.position.y) <= 2 && Math.Abs (ball_position.position.x - snow_position.position.x) <= 2) {
			//Audio
			if (audiosnow == 1) {
				AudioSource Audio;
				Audio = gameObject.AddComponent<AudioSource> ();
				Audio.clip = Resources.Load ("snow") as AudioClip;
				Audio.Play ();
				audiosnow = 0;
			}
			ball_position.position = snow_position.position;
			SnowFail ();
		}
		if (Math.Abs (ball_position.position.y - snow1_position.position.y) <= 2 && Math.Abs (ball_position.position.x - snow1_position.position.x) <= 2) {
			//Audio
			if (audiosnow == 1) {
				AudioSource Audio;
				Audio = gameObject.AddComponent<AudioSource> ();
				Audio.clip = Resources.Load ("snow") as AudioClip;
				Audio.Play ();
				audiosnow = 0;
			}

			ball_position.position = snow1_position.position;
			SnowFail ();
		}
		if (Math.Abs (ball_position.position.y - snow2_position.position.y) <= 2 && Math.Abs (ball_position.position.x - snow2_position.position.x) <= 2) {
			//Audio
			if (audiosnow == 1) {
				AudioSource Audio;
				Audio = gameObject.AddComponent<AudioSource> ();
				Audio.clip = Resources.Load ("snow") as AudioClip;
				Audio.Play ();
				audiosnow = 0;
			}

			ball_position.position = snow2_position.position;
			SnowFail ();
		}
		if (Math.Abs (ball_position.position.y - snow3_position.position.y) <= 2 && Math.Abs (ball_position.position.x - snow3_position.position.x) <= 2) {
			//Audio
			if (audiosnow == 1) {
				AudioSource Audio;
				Audio = gameObject.AddComponent<AudioSource> ();
				Audio.clip = Resources.Load ("snow") as AudioClip;
				Audio.Play ();
				audiosnow = 0;
			}

			ball_position.position = snow3_position.position;
			SnowFail ();
		}

		//ground
		if (!fail && ball_position.position.y < -10 && Math.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x) < 0.5 && Math.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y)<= 0.1) {	
			GameFail();
		}

		if (!fail && ball_position.position.y < -11) {
			GameFail ();
		}
		if (is_charge == true && transform.position.x >= end_point.x)
		{
			//Debug.Log (transform.position.x);
			//Debug.Log ("xx!!");
			GetComponent<Rigidbody2D>().velocity = speed_normal;

			chargeanimation.SetActive (false);

			is_charge = false;
			if (iceProtection > 0) {
				GetComponent<PolygonCollider2D> ().isTrigger = false;
			} else {
				GetComponent<CircleCollider2D>().isTrigger = false;
			}
//			if (!GetComponent<CircleCollider2D>())
//			{
//				gameObject.AddComponent<CircleCollider2D>();
//			}
//			GetComponent<CircleCollider2D>().isTrigger = false;
			GetComponent<Rigidbody2D>().gravityScale = 1;
		}
	}
		
	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "fire" && is_charge == false) {
			if (iceProtection > 0) {
				iceProtection--;
			}
			else {
				GameFail ();
			}
		}
		if (other.gameObject.tag == "star") {

			//Audio
			AudioSource Audio;
			Audio = gameObject.AddComponent<AudioSource> ();
			Audio.clip = Resources.Load ("star") as AudioClip;
			Audio.Play ();



			Destroy (other.gameObject);

			count = count + 1;

			if (count == 1) {
				star1.SetActive (true);
			}

			if (count == 2) {
				star2.SetActive (true);
			}

			if (count == 3) {
				star3.SetActive (true);
			}

		}
			if (other.gameObject.tag == "charge")//for charge
			{
				//Audio
				AudioSource Audio;
				Audio = gameObject.AddComponent<AudioSource> ();
				Audio.clip = Resources.Load ("charge") as AudioClip;
				Audio.Play ();

				Destroy(other.gameObject);
				is_charge = true;

			    chargeanimation.SetActive (true);
			  
				if (iceProtection > 0) {
					GetComponent<PolygonCollider2D> ().isTrigger = true;
				} else {
					GetComponent<CircleCollider2D>().isTrigger = true;
				}
				GetComponent<Rigidbody2D>().velocity = speed_charge;
				GetComponent<Rigidbody2D>().gravityScale = 0;
			}
			
		if (other.gameObject.tag == "icecube") {
			AudioSource Audio;
			Audio = gameObject.AddComponent<AudioSource> ();
			Audio.clip = Resources.Load ("icecube") as AudioClip;
			Audio.Play ();
		}

		//fire wall
		if (other.gameObject.tag == "fire" && is_charge == false) {
			Debug.Log ("fire");
			if (iceProtection > 0) {
				other.gameObject.SetActive (false);
			} 
			else if (iceProtection == 0) {
				other.gameObject.SetActive (false);
				Destroy (gameObject.GetComponent<PolygonCollider2D> ());
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("apple");
				gameObject.AddComponent<CircleCollider2D> ();
				gameObject.GetComponent<CircleCollider2D> ().sharedMaterial = Resources.Load<PhysicsMaterial2D> ("ballmaterial");
				gameObject.GetComponent<CircleCollider2D> ().radius = 3f;
				gameObject.GetComponent<CircleCollider2D> ().offset = new Vector2 (-0.5f, -1f);
				gameObject.transform.localScale = new Vector3 (0.25f, 0.25f, 1f);
			}
		}
				
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		//Audio
		if (collision.gameObject.tag == "wall" ) {
			AudioSource Audio = collision.gameObject.GetComponent<AudioSource> ();
			if (Audio == null) {
				Audio = collision.gameObject.AddComponent<AudioSource> ();
			}
			Audio.clip = Resources.Load ("wall123") as AudioClip;
			Audio.Play ();
		}

		if (collision.gameObject.tag == "line" || collision.gameObject.tag=="fireline") {
			//Audio
			AudioSource Audio;
			Audio = gameObject.AddComponent<AudioSource> ();
			Audio.clip = Resources.Load ("line123") as AudioClip;
			Audio.Play ();
		}

	}


	public void GameFail() {
		fail = true;
		Destroy (gameObject, 2);
		ButtonPanel.gameObject.SetActive (false);//
		Blackpanel2.gameObject.SetActive (true);//
	}
	public void SnowFail() {
		//ball_position.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("AppleInSnow");
		if (ball_position.position.y < -10) {
			GameFail ();
		}
	}
}
