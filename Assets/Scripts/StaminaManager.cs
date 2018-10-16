using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : MonoBehaviour
{

    private Stamina _stamina;
    private float _previousStamina = 0.0f;
    private GameObject _UIStaminaBar;
    // Use this for initialization
    void Start()
    {
        _stamina = GetComponent<Stamina>();
        _previousStamina = _stamina.GetCurrentStamina();

        _UIStaminaBar = GameObject.Find("PlayerStaminaBar");

		UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        CheckStamina();
    }

    void CheckStamina()
    {
        float newStamina = _stamina.GetCurrentStamina();

        if (newStamina != _previousStamina)
        {
            _previousStamina = newStamina;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        float perc = _stamina.GetCurrentStamina() / _stamina.GetMaxStamina();

        _UIStaminaBar.GetComponent<Slider>().value = perc;
    }
}
