using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	[SerializeField] private int _health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddHealth(int amount)
	{
		_health += amount;
	}

	public bool IsAlive()
	{
		return _health > 0;
	}
}
