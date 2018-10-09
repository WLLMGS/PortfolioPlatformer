using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverRobotBehavior : MonoBehaviour
{


    private float _moveSpeed = 2.5f;
    private GameObject _player;
    private bool _doFollowPlayer = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GoToPlayer();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            if (_player == null) _player = collider.gameObject;
            PlayerDetected();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            _doFollowPlayer = false;
        }

    }

    void PlayerDetected()
    {
        _doFollowPlayer = true;

        if (_player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else transform.localScale = new Vector3(1, 1, 1);
    }

    void GoToPlayer()
    {
        if (_doFollowPlayer)
        {
            float distance = Mathf.Abs(transform.position.x - _player.transform.position.x);

            if (distance > 1.0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(_player.transform.position.x, transform.position.y, transform.position.z), Time.deltaTime * _moveSpeed);
            }
        }
    }

}
