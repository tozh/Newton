using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCreaterScript : MonoBehaviour {
	AudioSource MusicAS;
	public GameObject MusicPrefab;
	public static bool MusicCreated = false;
	// Use this for initialization
	void Start () {
		if (MusicCreated==false) {
			GameObject music = GameObject.Instantiate (MusicPrefab);  
			music.AddComponent<SynchronizeVolScript> ();
			music.gameObject.tag = "music"; 
			MusicAS = music.AddComponent<AudioSource> ();
			MusicAS.clip = Resources.Load ("GameStart") as AudioClip;
			MusicAS.loop = true;
			MusicAS.Play ();
			MusicCreated = true;
			GameObject.DontDestroyOnLoad (music);
		}
	}
}
