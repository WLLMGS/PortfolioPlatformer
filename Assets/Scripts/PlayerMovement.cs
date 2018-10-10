using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _moveForce = 5.0f;
	[SerializeField] private float _maxSpeed = 5.0f;

	[SerializeField] private float _jumpForce = 50.0f;

    private Rigidbody2D _rigid;

    float _xaxis = 0.0f;
	
	bool _canJump = false;

		bool _doJump = false;
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();

#if DEBUG
        Assert.IsNotNull(_rigid, "DEPENDENCY ERROR: no rigidbody2d on player");
#endif
    }

    void Update()
    {
        _xaxis = Input.GetAxis("Horizontal");
		_doJump = Input.GetKeyDown(KeyCode.Space);

		CheckFlip();
		HandleJump();
	}

    void FixedUpdate()
    {
	    HandleHorizontalMovement();
    }

    void HandleHorizontalMovement()
    {
		if(Mathf.Abs(_rigid.velocity.x) < _maxSpeed) _rigid.AddForce(new Vector2(_moveForce * _xaxis, 0.0f));
		else _rigid.velocity = new Vector2(Mathf.Sign(_xaxis) * _maxSpeed, _rigid.velocity.y);

        if (Mathf.Approximately(_xaxis, 0.0f)) _rigid.velocity = new Vector2(0, _rigid.velocity.y);
    }

	void CheckFlip()
	{
		if(_xaxis > 0) transform.localScale = new Vector3(1,1,1);
		else if(_xaxis < 0) transform.localScale = new Vector3(-1,1,1);
	}

	void HandleJump()
	{
		if(_doJump && _canJump)
		{
			_canJump = false;
			_rigid.AddForce(new Vector2(0,_jumpForce), ForceMode2D.Impulse);
		}
	}

	 void OnCollisionEnter2D(Collision2D col)
    {
		if(col.gameObject.tag == "Ground") _canJump = true;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "screen")
		{
			Camera.main.transform.position = new Vector3(col.transform.position.x, col.transform.position.y, -100);
		}
	}

}
