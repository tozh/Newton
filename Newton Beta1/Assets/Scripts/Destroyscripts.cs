using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyscripts : MonoBehaviour {

	public Transform panel;

	public GameObject star1;
	public GameObject star2;
	public GameObject star3;
	public Ballscripts Ball;


	public int hp = 1;
	// Use this for initialization
	public bool isNewton = true;

	public void Damage(int damageCount) {
		hp -= damageCount;

		if (hp <= 0) {
			Destroy(gameObject);
			panel.gameObject.SetActive (true);
			Time.timeScale = 0;


		
			if (Ball.count >= 1) 
			{
				star1.SetActive (true);
			}
			
			//yield WaitForSeconds (1.0);
			if (Ball.count >= 2) 
			{
				star2.SetActive (true);
			}

			//yield WaitForSeconds (1.0);
			if (Ball.count >= 3) 
			{
				star3.SetActive (true);
			}


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