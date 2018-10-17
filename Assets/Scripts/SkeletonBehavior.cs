using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBehavior : MonoBehaviour
{


    private bool _inrange = false;
    private GameObject _target;
    private float _moveforce = 10.0f;
    private Rigidbody2D _rigid;

	private float _maxmoveforce = 3.0f;

    // Use this for initialization
    void Start()
    {
        _target = GameObject.Find("Player");
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_inrange) CheckDistance();
        else FollowPlayer();
    }


    void CheckDistance()
    {
        float distance = Vector2.Distance(transform.position, _target.transform.position);
        if (distance < 7.0f) _inrange = true;

    }

    void FollowPlayer()
    {
        float sign = 1.0f;

        if (transform.position.x > _target.transform.position.x) sign *= -1.0f;

		_rigid.AddForce(new Vector2(_moveforce * sign, 0), ForceMode2D.Force);

		if(Mathf.Abs(_rigid.velocity.x)  > _maxmoveforce)
		{
			_rigid.velocity = new Vector2(_maxmoveforce * Mathf.Sign(_rigid.velocity.x), _rigid.velocity.y);
		}

		transform.localScale = new Vector3(sign * -1.0f,1,1);
    }
}
