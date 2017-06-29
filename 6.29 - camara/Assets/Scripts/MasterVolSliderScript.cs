using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolSliderScript : MonoBehaviour {
	// Use this for initialization
	Slider slider;
	void Start () {
		slider = gameObject.GetComponent<Slider>();
		slider.value = AudioVolume.masterVolume;
		AudioListener.volume = AudioVolume.masterVolume;
	}

	public void changeMasterVol() {
		AudioVolume.masterVolume = slider.value;
		AudioListener.volume = slider.value;
	}
}
