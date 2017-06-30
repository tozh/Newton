using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynchronizeVolScript : MonoBehaviour {
	AudioSource MusicAS;
	void Start () {
		MusicAS = gameObject.GetComponent<AudioSource> ();
	}
	void Update() {
		if (MusicAS != null) {
			MusicAS.volume = AudioVolume.musicVolume;
			AudioListener.volume = AudioVolume.masterVolume;
		}
	}
}
