using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellcatScript : MonoBehaviour
{


    private float _sign = -1;
    private float _movespeed = 15.0f;

    private Rigidbody2D _rigid;
    // Use this for initialization
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovement();
    }
    void HandleMovement()
    {
        _rigid.AddForce(new Vector2(_movespeed * _sign, 0.0f), ForceMode2D.Force);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "ScreenBound")
        {
            //flip
            _rigid.velocity = Vector3.zero;
            _sign *= -1;
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "LevelBound")
        {
            _sign *= -1;
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}
