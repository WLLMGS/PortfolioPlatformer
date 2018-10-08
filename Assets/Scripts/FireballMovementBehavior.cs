using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovementBehavior : MonoBehaviour {

	private float _moveSpeed = 8.0f;

	private Rigidbody2D _rigid;

	private ProjectileStatsScript _stats;
	// Use this for initialization
	void Start () {
		_rigid = GetComponent<Rigidbody2D>();
	_stats = GetComponent<ProjectileStatsScript>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		HandleMovement();
	}

	void HandleMovement()
	{
		_rigid.velocity = transform.right * _moveSpeed * _stats.Direction;
	}
}
