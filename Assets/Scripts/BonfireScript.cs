using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireScript : MonoBehaviour
{


    private bool _inrange = false;
    private GameObject _light;
	private GameObject _tooltip;
    // Use this for initialization
    void Start()
    {
        _light = transform.Find("light").gameObject;
    	_tooltip = transform.Find("tooltip").gameObject;
	}

    // Update is called once per frame
    void Update()
    {
        CheckIfRest();
    }

    private void CheckIfRest()
    {
        if (_inrange && Input.GetKeyDown(KeyCode.E))
        {
            GameplayManager.GetInstance().NotifyNewSavepoint(transform.position);
            Debug.Log("SPAWN POS SET");
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            _light.SetActive(true);
			_tooltip.SetActive(true);
            _inrange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            _light.SetActive(false);
			_tooltip.SetActive(false);
            _inrange = false;
        }
    }
}
