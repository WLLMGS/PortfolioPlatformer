using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

	[SerializeField] private float _moveSpeed = 10.0f;
	[SerializeField] private float _jumpForce = 10.0f;

	[SerializeField] private float _maxMoveSpeed = 10.0f;


    private Rigidbody2D _rigid;

	private float _xAxis = 0.0f;

    // Use this for initialization
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();

#if DEBUG
        Assert.IsNotNull(_rigid, "DEPENDECY ERROR: No RigidBody2D in playermovement");
#endif
    }

	void Update()
	{
		_xAxis = Input.GetAxis("Horizontal");
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		HandleJump();
		HandleMovement();
		HandleDirection();
    }


    void HandleMovement()
    {
        //_rigid.velocity = new Vector2(_xAxis * _moveSpeed, _rigid.velocity.y);
		//_rigid.AddForce(new Vector2(_xAxis * _moveSpeed, 0.0f), ForceMode2D.Force);
		_rigid.AddRelativeForce(new Vector2(_xAxis * _moveSpeed, 0.0f));

		Debug.Log(_rigid.velocity);

		//clamp velocity
		_rigid.velocity = new Vector2(Mathf.Clamp(_rigid.velocity.x, -_maxMoveSpeed,_maxMoveSpeed), _rigid.velocity.y);
	
		if(_xAxis == 0.0f) _rigid.velocity = new Vector2(0.0f, _rigid.velocity.y);
	}

	void HandleDirection()
	{
		
		//handle direction
		if(_xAxis < 0) transform.localScale = new Vector3(-1,1,1);
		else if (_xAxis > 0) transform.localScale = new Vector3(1,1,1);

	}

	void HandleJump()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			//set velocity to zero before applying force
			//_rigid.velocity = Vector2.zero;
			_rigid.AddForce(new Vector2(0,_jumpForce), ForceMode2D.Impulse);
		}
	}
}
