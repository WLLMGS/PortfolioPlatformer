using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerScript : MonoBehaviour {

	[SerializeField] private float _damage = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			col.gameObject.GetComponent<Health>().AddHealth(-_damage);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			col.gameObject.GetComponent<Health>().AddHealth(-_damage);
		}
	}
}
