using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolSliderScript : MonoBehaviour {
	Slider slider;
	void Start () {
		slider = gameObject.GetComponent<Slider>();
		slider.value = AudioVolume.musicVolume;
	}

	public void changeMasterVol() {
		AudioVolume.musicVolume = slider.value;
	}
}
