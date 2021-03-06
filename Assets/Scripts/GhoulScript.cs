﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class GhoulScript : MonoBehaviour
{

    [SerializeField] private float _amplitude;
    private float _angle = 0.0f;


    private Vector2 _pushForce = new Vector2(10, 7);
    private Health _health;

    // Use this for initialization
    void Start()
    {
        _health = GetComponent<Health>();
        var collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
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



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            var obj = col.gameObject;

            var rigid = obj.GetComponent<Rigidbody2D>();

            if (rigid != null)
            {
                rigid.velocity = Vector2.zero;
                if (transform.position.x > obj.transform.position.x) rigid.AddForce(new Vector2(-_pushForce.x, _pushForce.y), ForceMode2D.Impulse);
                else rigid.AddForce(new Vector2(_pushForce.x, _pushForce.y), ForceMode2D.Impulse);
            }
        }

    }
}
