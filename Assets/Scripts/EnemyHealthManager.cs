using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class EnemyHealthManager : MonoBehaviour
{
	[SerializeField] private GameObject _deathAnimation;
    private Health _health;
    // Use this for initialization
    void Start()
    {
		_health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
		CheckIfAlive();
    }

	 void CheckIfAlive()
    {
        if (!_health.IsAlive())
        {
            Instantiate(_deathAnimation, new Vector3(transform.position.x, transform.position.y, -15), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
