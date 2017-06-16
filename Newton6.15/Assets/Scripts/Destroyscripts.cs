using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyscripts : MonoBehaviour {

	public GameObject VictoryPanel;//
	public GameObject ButtonPanel;//

	public GameObject star1;
	public GameObject star2;
	public GameObject star3;
	public Ballscripts Ball;
    public float waitTime = 1.0f;

	private List<Level> my_levels;



	public int hp = 1;
	// Use this for initialization
	public bool isNewton = true;

	void Start () 
	{
		//获取关卡
		my_levels = LevelSystem.LoadLevels ();
	}

	public void Damage(int damageCount) {
		
		hp -= damageCount;

		if (hp <= 0) {
			////////////////////////////////////////////////
			string name = SceneManager.GetActiveScene ().name;//levelx
			string id = name.Substring(5);
			Debug.Log (id);
			string nextLevelID = (int.Parse (id) + 1).ToString ();
			Debug.Log (nextLevelID);

			foreach (Level l in my_levels) 
			{	
				if(l.levelID.Equals(id)) {
					if(l.stars<Ball.count) {
						LevelSystem.SetLevels (id, Ball.count, true, false);//set this level, fail or succ
					}
					else {
						LevelSystem.SetLevels (id, l.stars, true, false);//set this level, fail or succ

					}
				}
				if (!id.Equals(6)) {
					if(l.levelID.Equals(nextLevelID)) 
					{
						if (l.firstplay) {// first play == true
							LevelSystem.SetLevels (nextLevelID, 0, true, true);
						}
					}
				}

			}
				
			Destroy(gameObject);

			VictoryPanel.gameObject.SetActive (true);//
			ButtonPanel.gameObject.SetActive (false);//

            //StartCoroutine(Wait(waitTime));
			if (Ball.count >= 1) 
			{
				star1.SetActive (true);
			}
            //StartCoroutine(Wait(waitTime));
            //yield WaitForSeconds (1.0);
            if (Ball.count >= 2) 
			{
				star2.SetActive (true);
			}
            //StartCoroutine(Wait(waitTime));
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

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}