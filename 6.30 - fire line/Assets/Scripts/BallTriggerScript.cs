using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTriggerScript : MonoBehaviour {
	public GameObject ball;
	int hp;
	const int MAX_HP = 80;
	// Use this for initialization
	void Start () {
		hp = 80;
		gameObject.AddComponent<CircleCollider2D> ();
		gameObject.GetComponent<CircleCollider2D> ().isTrigger = true;
		gameObject.GetComponent<CircleCollider2D> ().offset = ball.GetComponent<CircleCollider2D> ().offset;
		gameObject.GetComponent<CircleCollider2D> ().radius = 2 * ball.GetComponent<CircleCollider2D> ().radius;
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (hp);
		if (hp < MAX_HP) {
			hp += 2;
		}
		float colorRGB = (float)hp / MAX_HP;
		Color nowColor = new Color (colorRGB, colorRGB, colorRGB);
		ball.GetComponent<SpriteRenderer> ().color = nowColor;
		gameObject.GetComponent<Transform> ().localPosition = ball.transform.position;
	}
	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag=="fireline") 
		{
			//Debug.Log ("xxxxxxxxxxxxxxxxxx");
			if (ball.GetComponent<Ballscripts> ().iceProtection == 0 && ball.GetComponent<Ballscripts> ().is_charge == false) {
				hp -= 4;
				if (hp < 0) {
					ball.GetComponent<Ballscripts> ().GameFail ();
				}
			}

		}
	}
}
