using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynchronizeVolScript : MonoBehaviour {
	AudioSource music;
	// Use this for initialization
	void Start () {
		music = gameObject.GetComponent<AudioSource> ();
		music.volume = AudioVolume.musicVolume;
		AudioListener.volume = AudioVolume.masterVolume;
	}
}
