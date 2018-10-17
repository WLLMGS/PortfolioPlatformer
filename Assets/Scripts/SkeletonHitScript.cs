using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonHitScript : EnemyHit {

	// Use this for initialization
	override public void Hit()
	{
		Rigidbody2D _rigid = GetComponent<Rigidbody2D>();

		_rigid.velocity = Vector2.zero;
		_rigid.AddForce(new Vector2(100,0), ForceMode2D.Impulse);
		Debug.Log("SKELETON HIT");
	}
}
