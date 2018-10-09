using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovementBehavior : MonoBehaviour
{

    private float _moveSpeed = 8.0f;

    private Rigidbody2D _rigid;

    private ProjectileStatsScript _stats;

    [SerializeField] private GameObject _smoke;
    // Use this for initialization
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _stats = GetComponent<ProjectileStatsScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        _rigid.velocity = transform.right * _moveSpeed * _stats.Direction;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            Explode();
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        Instantiate(_smoke, transform.position + new Vector3(0,0,-5), Quaternion.identity);
    }
}
