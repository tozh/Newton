using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {
	public GameObject wall1;
	public GameObject wall2;
	public GameObject wall3;
	public GameObject ball;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "ball") {
			Destroy (gameObject);
			wall1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("firewall");
			wall2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("firewall");
			wall3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("firewall");
			wall1.GetComponent<BoxCollider2D>().isTrigger = true;
			wall2.GetComponent<BoxCollider2D>().isTrigger = true;
			wall3.GetComponent<BoxCollider2D>().isTrigger = true;
			ball.GetComponent<Ballscripts> ().isFired = true;
		}
	}

}
