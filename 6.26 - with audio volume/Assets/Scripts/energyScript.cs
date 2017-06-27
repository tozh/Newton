using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;
using UnityEditor.Sprites;
using System;

public class energyScript : MonoBehaviour {

	public float timeSpend = 0.0f;
	public float recoverRate = 0.5f;
	public float maxEnergy = 10;
	public float energyLeft = 10;
	public Transform unlimitedLine;
	public Transform unlimitedLine2;
	public Transform ball_position;
	public bool flag = false;
	public bool flag2 = false;

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		timeSpend += Time.deltaTime;
		//unlimitedLine
		if (!flag && Math.Abs (ball_position.position.y - unlimitedLine.position.y) <= 1 && Math.Abs (ball_position.position.x - unlimitedLine.position.x) <= 1) {
			energyLeft = 10000000000;
			timeSpend = -4f;
			Destroy (unlimitedLine.gameObject);
			flag = true;

		}
		if (!flag2 && Math.Abs (ball_position.position.y - unlimitedLine2.position.y) <= 1 && Math.Abs (ball_position.position.x - unlimitedLine2.position.x) <= 1) {
			energyLeft = 10000000000;
			timeSpend = -4f;
			Destroy (unlimitedLine2.gameObject);
			flag2 = true;

		}
		//
		if (timeSpend > 1) {
			energyLeft = Mathf.Min (maxEnergy, energyLeft + timeSpend*recoverRate);
			timeSpend = 0;
		}
	}
}