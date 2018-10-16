using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{


    private Health _health;
    private float _previousHP = 0;

    private GameObject _UIhealthbar;
    // Use this for initialization
    void Start()
    {
        _health = GetComponent<Health>();
        _previousHP = _health.GetCurrentHealth();
        _UIhealthbar = GameObject.Find("PlayerHealthbar");

        //update UI at the start of game
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
    }

    void CheckHealth()
    {
        float newHealth = _health.GetCurrentHealth();

        if (newHealth != _previousHP)
        {
            if (newHealth == 0)
            {
                //notify gameplay manager
				GameplayManager.GetInstance().NotifyPlayerDead();
				_previousHP = newHealth;
                UpdateUI();
            }
            else
            {
                //update UI
                _previousHP = newHealth;
                UpdateUI();
			}
        }

    }
    void UpdateUI()
    {
        //calculate fill
        float percentage = _health.GetCurrentHealth() / _health.GetMaxHealth();

        _UIhealthbar.GetComponent<Slider>().value = percentage;
    }
}
