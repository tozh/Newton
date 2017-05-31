using UnityEngine;
using System.Collections;

public class NewtonScript : MonoBehaviour
{
	public Vector3 pointB;
	public int hp = 1;

	IEnumerator Start()
	{
		var pointA = transform.position;
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

	/// <summary>
	/// Enemy or player?
	/// </summary>
	public bool isEnemy = true;

	/// <summary>
	/// Inflicts damage and check if the object should be destroyed
	/// </summary>
	/// <param name="damageCount"></param>
	public void Damage(int damageCount)
	{
		hp -= damageCount;

		if (hp <= 0)
		{
			// Dead!
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		AppleScript shot = otherCollider.gameObject.GetComponent<AppleScript>();
		if (shot != null)
		{
			// Avoid friendly fire
			if (shot.isEnemyShot != isEnemy)
			{
				Damage(shot.damage);

				// Destroy the shot
				Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			}
		}
	}
}