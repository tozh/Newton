using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowBridgeScript : MonoBehaviour {
	public GameObject rainbowBridgePrefab;
	private bool rainbowEnable = false;
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag=="ball") 
		{
			Destroy (gameObject);
			GameObject rainbowBridge = Instantiate (rainbowBridgePrefab);
			rainbowBridge.SetActive (true);
			Destroy (rainbowBridge.gameObject, 5);
		}
	}
}
