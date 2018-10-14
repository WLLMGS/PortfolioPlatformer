using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawnerScript : MonoBehaviour {


	[SerializeField] private GameObject _mob;

	private GameObject _spawnedInstance;
	public void SpawnMob()
	{
		if(_spawnedInstance != null) Destroy(_spawnedInstance);
		_spawnedInstance = Instantiate(_mob, transform.position, Quaternion.identity);
	}
}
