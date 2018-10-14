using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour {

	private static GameplayManager _instance = null;

	private List<GameObject> _spawners = new List<GameObject>();
	void Awake()
	{
		if(_instance == null) _instance = this;
	}
	// Use this for initialization
	void Start () {
		GameObject[] s = GameObject.FindGameObjectsWithTag("Spawner");

		foreach(GameObject obj in s)
		{
			_spawners.Add(obj);
			obj.GetComponent<MobSpawnerScript>().SpawnMob();
		}


	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R))
		{
			RespawnAllMobs();
		}
	}

	public static GameplayManager GetInstance()
	{
		return _instance;
	}

	private void RespawnAllMobs()
	{
		foreach(GameObject obj in _spawners)
		{
			obj.GetComponent<MobSpawnerScript>().SpawnMob();
		}
	}
}
