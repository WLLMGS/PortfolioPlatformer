using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{


    [SerializeField] private GameObject _slashEffect;

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
            RaycastHit2D hit = Physics2D.Raycast(_swordpoint.transform.position, transform.right * x, 1.0f);

            if (hit)
            {
                if (hit.collider.gameObject.tag == "Box")
                {
					SpawnSlash(hit.point.x, hit.point.y);
                    var rb = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                    rb.AddForce(transform.right * x * 15.0f, ForceMode2D.Impulse);
                }
            }
        }
    }

	void SpawnSlash(float x, float y)
	{
		Instantiate(_slashEffect, new Vector3(x, y, -10), Quaternion.identity);
	}
}
