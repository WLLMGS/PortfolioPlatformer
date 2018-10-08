using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogMovement : MonoBehaviour
{


    [SerializeField] private float _moveSpeed = 2.0f;

	[SerializeField] Vector4 _color;
    // Use this for initialization
    void Start()
    {
		_color /= 255.0f;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color *= new Color(_color.x, _color.y, _color.z, _color.w );

		
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        transform.position += new Vector3(_moveSpeed * Time.deltaTime, 0, 0);
    }
}
