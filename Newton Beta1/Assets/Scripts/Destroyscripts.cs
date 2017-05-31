using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyscripts : MonoBehaviour {
	public int hp = 1;
	// Use this for initialization
	public bool isNewton = true;

	public void Damage(int damageCount) {
		hp -= damageCount;

		if (hp <= 0) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		Hitscripts hit = otherCollider.gameObject.GetComponent<Hitscripts> ();
		if (hit != null) {
			//Avoid friendly shots
			if (hit.isNewtonHit != isNewton) {
				Damage (hit.damage);
				// Destory the shot
				Destroy(hit.gameObject);
			}
		}

	}
}