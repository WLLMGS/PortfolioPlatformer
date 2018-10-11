using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAnimation : MonoBehaviour
{

    [SerializeField] private float _cooldown = 0.25f;

    private float _timer = 0.0f;

    private float _angle;


	private float _factor = 0.05f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _angle++;
        _timer -= Time.deltaTime;

        if(_timer <= 0.0f) Flicker();


        //transform.localScale += 0.1f * new Vector3(Mathf.Cos(_angle * Mathf.Deg2Rad) + 1,Mathf.Cos(_angle * Mathf.Deg2Rad) + 1,0 ) * Time.deltaTime;
    }

    void Flicker()
    {

        _timer = _cooldown;

        // float r = Random.Range(0.75f, 1.25f);

        // transform.localScale = new Vector3(r, r, r);

        var currentScale = transform.localScale;

		
        if (currentScale.x < 0.80f)
		{
			//currentScale = new Vector3(1.25f, 1.25f, 1.25f);
			_factor = 0.05f;
		}
		if(currentScale.x > 1.25f)
		{
			_factor = -0.05f;
		} 

        currentScale += new Vector3(_factor, _factor, 0);

        transform.localScale = currentScale;
    }
}
