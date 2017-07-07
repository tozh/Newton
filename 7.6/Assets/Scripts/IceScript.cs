using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceScript : MonoBehaviour {
	public GameObject ball;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag=="ball") 
		{
			//Audio
			AudioSource Audio;
			Audio = gameObject.AddComponent<AudioSource> ();
			Audio.clip = Resources.Load ("ice cube") as AudioClip;
			Audio.Play ();


			Destroy (ball.GetComponent<CircleCollider2D>());
			Destroy (gameObject);
			ball.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("iceapple");
			ball.AddComponent<PolygonCollider2D> ();
			ball.GetComponent<PolygonCollider2D> ().sharedMaterial = Resources.Load<PhysicsMaterial2D> ("slippery");
			ball.transform.localScale = new Vector3 (0.5f, 0.5f, 1f);
			ball.GetComponent<Ballscripts> ().iceProtection = 1;
			if (ball.GetComponent<Ballscripts> ().is_charge) {
				print ("xxxxxxx");
				ball.GetComponent<PolygonCollider2D> ().isTrigger = true;
			}
		}
	}
}
