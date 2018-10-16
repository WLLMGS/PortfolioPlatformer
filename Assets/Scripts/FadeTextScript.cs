using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTextScript : MonoBehaviour {


	private float _fadespeed = 0.5f;
	private Text _text;
	// Use this for initialization
	void Start () {
		_text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		FadeText();
	}

	public void ReActivate()
	{
		_text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 1.0f);
	}

	void FadeText()
	{
		float alpha = _text.color.a;
		alpha -= _fadespeed * Time.deltaTime;

		_text.color = new Color(_text.color.r, _text.color.g, _text.color.b, alpha);
	}

	public bool IsDone()
	{
		return _text.color.a <= 0;
	}
}
