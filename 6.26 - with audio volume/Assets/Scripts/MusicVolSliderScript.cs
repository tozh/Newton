using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolSliderScript : MonoBehaviour {
	Slider slider;
	public AudioSource music;
	void Start () {
		
		slider = gameObject.GetComponent<Slider>();
		slider.value = AudioVolume.musicVolume;
		music.volume = AudioVolume.musicVolume;
	}

	public void changeMasterVol() {
		AudioVolume.musicVolume = slider.value;
		music.volume = slider.value;
	}
}
