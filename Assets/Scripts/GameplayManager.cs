using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private GameObject _Smoke;

    private static GameplayManager _instance = null;

    private List<GameObject> _spawners = new List<GameObject>();

    private GameObject _player;
    private GameObject _UIfaithRestored;
    private GameObject _UIyoudied;
    private Vector3 _respawnpoint;

    private bool _isplayerdead = false;
    void Awake()
    {
        if (_instance == null) _instance = this;
    }
    // Use this for initialization
    void Start()
    {
        GameObject[] s = GameObject.FindGameObjectsWithTag("Spawner");

        foreach (GameObject obj in s)
        {
            _spawners.Add(obj);
            obj.GetComponent<MobSpawnerScript>().SpawnMob();
        }

        _player = GameObject.Find("Player");
        _UIfaithRestored = GameObject.Find("FaithRestored");
        _UIyoudied = GameObject.Find("YouDied");
        SetClosestBonfire();
    }

    void SetClosestBonfire()
    {
        GameObject[] bonfires = GameObject.FindGameObjectsWithTag("Bonfire");

        float distance = 20000.0f;
        Vector3 closest = Vector3.zero;

        foreach (GameObject bonfire in bonfires)
        {
            float d = Vector2.Distance(bonfire.transform.position, _player.transform.position);

            if (d < distance)
            {
                distance = d;
                closest = bonfire.transform.position;
            }
        }

        _respawnpoint = closest;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            NotifyPlayerDead();
        }

        if (_isplayerdead)
        {
            if (_UIyoudied.GetComponent<FadeTextScript>().IsDone())
            {
                ResetPlayer();
                _isplayerdead = false;
            }
        }
    }

    public static GameplayManager GetInstance()
    {
        return _instance;
    }

    private void RespawnAllMobs()
    {
        foreach (GameObject obj in _spawners)
        {
            obj.GetComponent<MobSpawnerScript>().SpawnMob();
        }
    }

    public void NotifyPlayerDead()
    {
        _player.SetActive(false);
        _UIyoudied.GetComponent<FadeTextScript>().ReActivate();
        _isplayerdead = true;
        Instantiate(_Smoke, _player.transform.position, Quaternion.identity);
    }


    public void ResetPlayer()
    {
        //respawn player
        _player.SetActive(true);
        _player.transform.position = new Vector3(_respawnpoint.x, _respawnpoint.y, _player.transform.position.z);
        _player.GetComponent<Health>().ResetHealth();
        _player.GetComponent<Stamina>().ResetStamina();
        //respawn all the enemies
        RespawnAllMobs();
    }
    public void NotifyNewSavepoint(Vector3 position)
    {
        _respawnpoint = position;
        _player.GetComponent<Health>().ResetHealth();
        _player.GetComponent<Stamina>().ResetStamina();
        _UIfaithRestored.GetComponent<FadeTextScript>().ReActivate();
        RespawnAllMobs();
    }
}
