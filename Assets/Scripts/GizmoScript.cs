using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoScript : MonoBehaviour
{

	[SerializeField] Color _gizmoColor = new Color(1,0,0,0.5f);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.color = _gizmoColor;
        //Gizmos.DrawSphere(transform.position, 1.0f);

		Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
