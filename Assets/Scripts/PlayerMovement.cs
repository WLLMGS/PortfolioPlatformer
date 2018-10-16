using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _moveForce = 5.0f;
    [SerializeField] private float _maxSpeed = 5.0f;

    [SerializeField] private float _jumpForce = 50.0f;
    [SerializeField] private float _dashCost = 25.0f;

    private bool _IsGrounded = false;

    private Rigidbody2D _rigid;

    private Stamina _stamina;

    float _xaxis = 0.0f;

    bool _canJump = false;

    bool _doJump = false;
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _stamina = GetComponent<Stamina>();
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
        HandleDash();
    }

    void FixedUpdate()
    {
        HandleHorizontalMovement();
    }

    void HandleHorizontalMovement()
    {
        if (Mathf.Abs(_rigid.velocity.x) < _maxSpeed) _rigid.AddForce(new Vector2(_moveForce * _xaxis, 0.0f));
    }

    void CheckFlip()
    {
        if (_xaxis > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (_xaxis < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    void HandleJump()
    {
        if (_doJump && _canJump)
        {
            _canJump = false;
            _rigid.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }
    }

    void HandleDash()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (_stamina.GetCurrentStamina() >= _dashCost)
            {
                //apply more force if player is grounded to compensate for friction
                Vector2 force;
                if (!_IsGrounded) force = new Vector2(_jumpForce * Mathf.Sign(transform.localScale.x), 0.0f);
                else force = new Vector2(_jumpForce * Mathf.Sign(transform.localScale.x) * 1.5f, 0.0f);
                _rigid.AddForce(force, ForceMode2D.Impulse);

                //subtract stamine
                _stamina.AddStamina(-_dashCost);
            }

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            _canJump = true;
            _IsGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            _IsGrounded = false;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "screen")
        {
            Camera.main.transform.position = new Vector3(col.transform.position.x, col.transform.position.y, -100);
        }
    }

}
