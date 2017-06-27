using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	public void Next() {

		string nextLevel = "level";
		string name = SceneManager.GetActiveScene ().name;
		int id = int.Parse(name.Substring(5));
		if (id < 6) {

			string nextLevelID = (id + 1).ToString ();
			nextLevel += nextLevelID;
			SceneManager.LoadScene (nextLevel);
		} else if (id == 6) 
		{
			SceneManager.LoadScene ("LevelSelect");
		}

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
