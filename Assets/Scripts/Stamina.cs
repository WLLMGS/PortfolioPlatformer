using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{

    [SerializeField] private float _maxStamina;
    [SerializeField] private float _staminaRegenRate = 20.0f;
    private float _currentStamina;

    // Use this for initialization
    void Start()
    {
        _currentStamina = _maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        RegenStamina();
    }

    void RegenStamina()
    {
        _currentStamina += _staminaRegenRate * Time.deltaTime;
        _currentStamina = Mathf.Min(_currentStamina, _maxStamina);
    }
    public void AddStamina(float stamina)
    {
        _currentStamina += stamina;
    }

    public float GetCurrentStamina()
    {
        return _currentStamina;
    }

    public float GetMaxStamina()
    {
        return _maxStamina;
    }

    public void SetStamina(float stamina)
    {
        _currentStamina = stamina;
    }

    public void ResetStamina()
    {
        _currentStamina = _maxStamina;
    }
}
