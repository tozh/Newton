using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitscripts : MonoBehaviour {
	public int damage = 1;
	public Vector3 pointB;
	public bool isNewtonHit = false;

	IEnumerator Start()
	{
		var pointA = transform.position;
		Destroy (gameObject, 40);
		while(true)
		{
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
		}
	}

	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		var i= 0.0f;
		var rate= 1.0f/time;
		while(i < 1.0f)
		{
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null;
		}
	}

	// Use this for initialization
//	void Start () {
//		Destroy (gameObject, 40);
//	}

}