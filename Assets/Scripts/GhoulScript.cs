﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class GhoulScript : MonoBehaviour {


	[SerializeField] private float _amplitude;
	private float _angle = 0.0f;

	private Health _health;

	// Use this for initialization
	void Start () {
		_health = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
		HandleMovement();
		CheckIfAlive();
	}

	void HandleMovement()
	{
		++_angle;
		float newY = 0.0f;

		newY = transform.position.y + _amplitude * Mathf.Cos(_angle * Mathf.Deg2Rad) * Time.deltaTime;

		transform.position = new Vector3
		(
			transform.position.x,
			newY,
			transform.position.z
		);
	}

	void CheckIfAlive()
	{
		if(!_health.IsAlive())
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		var obj = col.gameObject;

		var rigid = obj.GetComponent<Rigidbody2D>();

		if(rigid != null)
		{
			if(transform.position.x > obj.transform.position.x)	rigid.AddForce(new Vector2(-20,10), ForceMode2D.Impulse);
			else rigid.AddForce(new Vector2(20,10), ForceMode2D.Impulse);
		} 
			
	}
}
