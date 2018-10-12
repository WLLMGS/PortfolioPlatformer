using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{


    private float _waittime = 0.0f;

    private Collider2D _collider;

    private float _cd = 0.15f;

    // Use this for initialization
    void Start()
    {
        _collider = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        HandlePlatform();
    }

    void HandlePlatform()
    {
        if (Input.GetKey(KeyCode.S))
        {
            _waittime += Time.deltaTime;
            if (_waittime > _cd)
            {
                _collider.enabled = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            _waittime = 0.0f;
            _collider.enabled = true;
        }
    }

}
