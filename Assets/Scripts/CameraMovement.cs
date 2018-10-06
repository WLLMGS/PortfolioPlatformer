using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private GameObject _player;

    private Vector3 _previousPosition;
    // Use this for initialization
    void Start()
    {
        _player = GameObject.Find("Player");
        _previousPosition = _player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
		Vector3 displacement = _player.transform.position - _previousPosition;

		transform.position += displacement;

		_previousPosition = _player.transform.position;
    }
}
