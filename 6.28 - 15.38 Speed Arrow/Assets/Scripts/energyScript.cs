﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;
using UnityEditor.Sprites;
using System;

public class energyScript : MonoBehaviour {

	public float timeSpend = 0.0f;
	private float recoverRate = 0.5f;
	public float maxEnergy = 20;
	public float energyLeft = 20;
	public Transform unlimitedLine;
	public Transform unlimitedLine2;
	public Transform ball_position;
	public bool flag = false;
	public bool flag2 = false;
	public GameObject EnergyBarShow;

	void Start () {
		//EnergyBarShow.GetComponent<EnergyBar> ().valueCurrent = 200;

	}

	// Update is called once per frame
	void Update () {
		timeSpend += 0.1f;
		//unlimitedLine
		if (!flag && Math.Abs (ball_position.position.y - unlimitedLine.position.y) <= 2 && Math.Abs (ball_position.position.x - unlimitedLine.position.x) <= 2) {
			energyLeft = 10000000000;
			maxEnergy = energyLeft;
			timeSpend = -4f;
			Destroy (unlimitedLine.gameObject);
			flag = true;
			//EnergyBarShow.GetComponent<EnergyBar> ().valueCurrent = 100;
		}
		if (!flag2 && Math.Abs (ball_position.position.y - unlimitedLine2.position.y) <= 2 && Math.Abs (ball_position.position.x - unlimitedLine2.position.x) <= 2) {
			energyLeft = 10000000000;
			maxEnergy = energyLeft;
			timeSpend = -4f;
			Destroy (unlimitedLine2.gameObject);
			flag2 = true;
			//EnergyBarShow.GetComponent<EnergyBar> ().valueCurrent = 100;
		}
		//
		if (timeSpend >= 0.1) {
			energyLeft = Mathf.Min (maxEnergy, energyLeft + timeSpend*recoverRate);
			maxEnergy = 20;
			timeSpend = 0;
		}

		EnergyBarShow.GetComponent<EnergyBar> ().valueCurrent = (int)((energyLeft / maxEnergy) * 100);
	}
}