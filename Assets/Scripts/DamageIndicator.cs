﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicator : MonoBehaviour {

	private float _speed = 3.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(0,_speed,0) * Time.deltaTime;
	}
}
