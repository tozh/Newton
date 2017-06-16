using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceScript : MonoBehaviour {
	public GameObject ball;
	public PhysicsMaterial2D slippery;


	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag=="ball") 
		{
			Destroy (ball.GetComponent<CircleCollider2D>());
			Destroy (gameObject);
			ball.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("iceapple");
			ball.AddComponent<PolygonCollider2D> ();
			ball.GetComponent<PolygonCollider2D> ().sharedMaterial = slippery;
			ball.transform.localScale = new Vector3 (0.4f, 0.4f, 1f);
		}
	}
}
