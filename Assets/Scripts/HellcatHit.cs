using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellcatHit : EnemyHit {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Hit()
	{
		GetComponent<HellcatScript>().ChangeDirection();
	}
}
