using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMusicScript : MonoBehaviour {
	AudioSource MusicAS;
	GameObject AS;
	// Use this for initialization
	void Start () {
		AS = GameObject.FindWithTag ("music");
		if (AS != null) {
			MusicAS = AS.GetComponent<AudioSource> ();
			string sceneName = AS.GetComponent<SynchronizeVolScript> ().sceneName;
			string thisSceneName = SceneManager.GetActiveScene ().name;

			if (sceneName!=thisSceneName) {
				if (thisSceneName == "level1" || thisSceneName == "level2" || thisSceneName == "level3") {
					AS.GetComponent<SynchronizeVolScript> ().sceneName = thisSceneName;
					MusicAS.clip = Resources.Load (thisSceneName+"bgm") as AudioClip;
					MusicAS.loop = true;
					MusicAS.Play ();
				} else if ((thisSceneName == "GameStart" && sceneName != "LevelSelect") || (thisSceneName == "LevelSelect" && sceneName != "GameStart")) {
					AS.GetComponent<SynchronizeVolScript> ().sceneName = thisSceneName;
					MusicAS.clip = Resources.Load ("GameStart") as AudioClip;
					MusicAS.loop = true;
					MusicAS.Play ();
				} 
			}
		}
	}
}
