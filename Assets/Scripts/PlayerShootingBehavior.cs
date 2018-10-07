using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerShootingBehavior : MonoBehaviour
{

    [SerializeField] private GameObject _projectile;

    [SerializeField] private float _firerate = 0.15f;

    private float _timer = 0.0f;


    private GameObject _gunpointer;

    // Use this for initialization
    void Start()
    {
        _gunpointer = transform.Find("gunpoint").gameObject;

#if DEBUG
        Assert.IsNotNull(_gunpointer, "gunpoint not found on player");
#endif
    }

    // Update is called once per frame
    void Update()
    {
        HandleShooting();
    }

    void HandleShooting()
    {
        //count down timer
        _timer -= Time.deltaTime;

        if (Input.GetMouseButton(0) && _timer <= 0.0f)
        {
            //reset timer
            _timer = _firerate;
            //shoot
           GameObject obj =  Instantiate(_projectile, _gunpointer.transform.position, Quaternion.identity);
			obj.transform.localScale = transform.localScale;
			obj.GetComponent<ProjectileStatsScript>().Direction = (int)obj.transform.localScale.x;
		}
    }
}
