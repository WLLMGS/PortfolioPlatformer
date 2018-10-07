using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour {

	[SerializeField] private float _moveSpeed = 10.0f;

	private GameObject _player;

	private Vector3 _previousPosition;
	
	private float _zAxis = 0.0f;
	// Use this for initialization
	void Start () {
		_player = GameObject.Find("Player");
		_previousPosition = _player.transform.position;
		_zAxis = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		HandleMovement();		
	}

	void HandleMovement()
	{
		Vector3 currentPlayerPos = _player.transform.position;
		
		float dx = currentPlayerPos.x - _previousPosition.x;
		float dy = currentPlayerPos.y - _previousPosition.y;

		_previousPosition = currentPlayerPos;

		float displacementX = (-dx * Time.deltaTime * _moveSpeed) / (_zAxis / 2.0f);
		float displacementY = (-dy * Time.deltaTime * _moveSpeed) / (_zAxis / 5.0f);		


		transform.position += new Vector3(displacementX, displacementY,0);
	}
}
