using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	[SerializeField] private float _health;
	private float _maxhealth;
	// Use this for initialization
	void Start () {
		_maxhealth = _health;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddHealth(float amount)
	{
		_health += amount;
	}

	public bool IsAlive()
	{
		return _health > 0;
	}

	public float GetCurrentHealth()
	{
		return _health;
	}

	public float GetMaxHealth()
	{
		return _maxhealth;
	}

	public void SetHealth(float health)
	{
		_health = health;
	}

	public void ResetHealth()
	{
		_health = _maxhealth;
	}
}
