using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SynchronizeVolScript : MonoBehaviour {
	AudioSource MusicAS;
	public string sceneName;
	void Start () {
		MusicAS = gameObject.GetComponent<AudioSource> ();
		sceneName = SceneManager.GetActiveScene ().name;
	}
	void Update() {
		if (MusicAS != null) {
			MusicAS.volume = AudioVolume.musicVolume;
			AudioListener.volume = AudioVolume.masterVolume;
		}
	}
}
