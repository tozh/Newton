using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {
	public int hp = 1;
	// Use this for initialization
	public bool isEnemy = true;

	public void Damage(int damageCount) {
		hp -= damageCount;

		if (hp <= 0) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript> ();
		if (shot != null) {
			//Avoid friendly shots
			if (shot.isEnemyShot != isEnemy) {
				Damage (shot.damage);
				// Destory the shot
				Destroy(shot.gameObject);
			}
		}

	}
}
