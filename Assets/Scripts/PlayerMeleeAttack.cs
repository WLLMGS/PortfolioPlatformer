using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{


    [SerializeField] private GameObject _slashEffect;
    [SerializeField] private GameObject _damageIndicator;

    private GameObject _swordpoint;

    // Use this for initialization
    void Start()
    {
        _swordpoint = transform.Find("swordpoint").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        CheckAttack();
    }

    void CheckAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float x = transform.localScale.x;
            //RaycastHit2D hit = Physics2D.Raycast(_swordpoint.transform.position, transform.right * x, 1.0f);
            RaycastHit2D hit = Physics2D.CircleCast(_swordpoint.transform.position, 1.0f, transform.right * x, 1.0f);

            if (hit)
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    SpawnSlash(hit.collider.transform.position.x, hit.collider.transform.position.y);
					//SpawnSlash(hit.point.x, hit.point.y);
                    SpawnDamageIndicator(hit.point.x, hit.point.y);
                    hit.collider.gameObject.GetComponent<Health>().AddHealth(-1);
                }
            }
        }
    }

	void SpawnSlash(float x, float y)
	{
		Instantiate(_slashEffect, new Vector3(x, y, -10), Quaternion.identity);
	}

    void SpawnDamageIndicator(float x, float y)
    {
        Instantiate(_damageIndicator, new Vector3(x,y,-15), Quaternion.identity);
    }
}
