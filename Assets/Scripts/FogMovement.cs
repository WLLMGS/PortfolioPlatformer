using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogMovement : MonoBehaviour
{


    [SerializeField] private float _moveSpeed = 2.0f;

	[SerializeField] Vector4 _color;

    private GameObject _fogfinish;
    private GameObject _fogreset;

    // Use this for initialization
    void Start()
    {
		_color /= 255.0f;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color *= new Color(_color.x, _color.y, _color.z, _color.w );

		_fogfinish = gameObject.transform.parent.Find("FogFinish").gameObject;
        _fogreset = gameObject.transform.parent.Find("FogReset").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        transform.position += new Vector3(_moveSpeed * Time.deltaTime, 0, 0);

        if(transform.position.x < _fogfinish.transform.position.x)
        {
            transform.position = new Vector3(_fogreset.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
