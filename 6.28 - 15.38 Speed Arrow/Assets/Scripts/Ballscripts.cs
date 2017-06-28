using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;
using UnityEditor.Sprites;
using System;

public class Ballscripts : MonoBehaviour {
	
	Rigidbody2D rbody2D;
	public Transform ball_position;
	public Transform crow_position;
	public Transform snow_position;

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

	private Vector3 charge_point;
	private Vector3 end_point;
	private Vector3 speed_charge = new Vector3(30,0,0);
	private Vector3 speed_normal = new Vector3(10,0,0);
	private Vector3 position;

	private bool is_charge = false;


	public bool fail = false;

	public PhysicsMaterial2D ballMaterial;

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

		charge_point = charge.transform.position;
		end_point = charge_point;
		end_point.x = end_point.x + 28.2f;

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
			ball_position.position = crow_position.position;
			if (ball_position.position.x < -12) {
				GameFail();
			}
		}
		//left side
		if (ball_position.position.x < -23) {
			GameFail();
		}
		//
		//		if (!fail && (snow_position.position.y - ball_position.position.y) <= 1 && Math.Abs(snow_position.position.x - ball_position.position.x) <= 1) {
		//			Debug.Log ("should fail 111111");
		//			GameFail();
		//		}
		//
		//
		//if (!fail && ball_position.position.y < -10 && Math.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x) < 0.5 && Math.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y)<= 0.1 || !fail && Math.Abs(ball_position.position.x)>7.5) {
		if (!fail && ball_position.position.y < -10 && Math.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x) < 0.5 && Math.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y)<= 0.1) {	
			GameFail();
		}

		if (is_charge == true && transform.position.x >= end_point.x)
		{
			GetComponent<Rigidbody2D>().velocity = speed_normal;
			is_charge = false;
			if (!GetComponent<CircleCollider2D>())
			{
				gameObject.AddComponent<CircleCollider2D>();
			}
			GetComponent<CircleCollider2D>().isTrigger = false;
			GetComponent<Rigidbody2D>().gravityScale = 1;
		}
	}
		
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "wall" && is_charge == false) {
			if (iceProtection > 0) {
				iceProtection--;
			}
			else {
				GameFail ();
			}
		}
		if (other.gameObject.tag == "star") {
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
				Destroy(other.gameObject);
				is_charge = true;
				GetComponent<Rigidbody2D>().velocity = speed_charge;
				GetComponent<Rigidbody2D>().gravityScale = 0;
				GetComponent<CircleCollider2D>().isTrigger = true;
			}
				
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "wall" && is_charge == false) {
			if (iceProtection > 0) {
				other.gameObject.SetActive (false);
			} 
			else if (iceProtection == 0) {
				other.gameObject.SetActive (false);
				Destroy (gameObject.GetComponent<PolygonCollider2D> ());
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("apple");
				gameObject.AddComponent<CircleCollider2D> ();
				gameObject.GetComponent<CircleCollider2D> ().sharedMaterial = Resources.Load<PhysicsMaterial2D> ("ballmaterial");
				gameObject.GetComponent<CircleCollider2D> ().radius = 0.58f;
				gameObject.GetComponent<CircleCollider2D> ().offset = new Vector2 (-0.1f, -0.1f);
				gameObject.transform.localScale = new Vector3 (0.8f, 0.8f, 1f);
			}
		}
	}
	void GameFail() {
		fail = true;
		Destroy (gameObject, 2);
		ButtonPanel.gameObject.SetActive (false);//
		Blackpanel2.gameObject.SetActive (true);//
	}
}
