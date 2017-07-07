using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour {

	public GameObject ball;
	public GameObject thisPortal;
	public GameObject theOtherPortal;

	private Vector3 positionThisToTheOther;
	private float rotationThisToTheOther;
	private PortalScript theOtherPortalScene;

	public bool canInto;

	// Use this for initialization
	void Start () {
		positionThisToTheOther = theOtherPortal.GetComponent<Transform> ().localPosition - thisPortal.GetComponent<Transform> ().localPosition;

		rotationThisToTheOther = Quaternion.Angle(theOtherPortal.GetComponent<Transform> ().localRotation, thisPortal.GetComponent<Transform> ().localRotation);
		theOtherPortalScene = theOtherPortal.GetComponent<PortalScript> ();
		canInto = true;
	}

	// Update is called once per frame
	//	void Update () {
	//		
	//	}

	void OnTriggerEnter2D(Collider2D other)
	{	
		if (canInto) {
			if (other.gameObject == ball) {

				//Audio
				AudioSource Audio;
				Audio = gameObject.AddComponent<AudioSource> ();
				Audio.clip = Resources.Load ("portal") as AudioClip;
				Audio.Play ();

				theOtherPortalScene.canInto = false;
				ball.GetComponent<Transform> ().localPosition += positionThisToTheOther;
				Vector3 speed = new Vector3 (ball.GetComponent<Rigidbody2D> ().velocity.x, -ball.GetComponent<Rigidbody2D> ().velocity.y, 0); 
				if (theOtherPortal.GetComponent<Transform> ().localRotation.z + thisPortal.GetComponent<Transform> ().localRotation.z> 0) {
					rotationThisToTheOther = rotationThisToTheOther;
				} else {
					rotationThisToTheOther = -rotationThisToTheOther;
				}
				Vector3 newSpeed = Quaternion.AngleAxis (rotationThisToTheOther, new Vector3 (0, 0, 1))*speed;
				ball.GetComponent<Rigidbody2D> ().velocity = newSpeed;
			}
		}
	}
	void OnTriggerExit2D(Collider2D other) 
	{	
		if (other.gameObject == ball) {
			this.canInto = true;
		}
	}
}


