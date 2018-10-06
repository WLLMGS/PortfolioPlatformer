using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerAnimationBehavior : MonoBehaviour
{

    private Animator _animator;
    private Rigidbody2D _rigid;

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigid = GetComponent<Rigidbody2D>();

#if DEBUG
        Assert.IsNotNull(_animator, "DEPENDENCY ERROR: no animator found in PlayerAnimationBehavior Script");
        Assert.IsNotNull(_rigid, "DEPENDENCY ERROR: no RigidBody2D found in PlayerAnimationBehavior Script");
#endif
    }

    // Update is called once per frame
    void Update()
    {
		CheckIfMoving();
    }

	void CheckIfMoving()
	{
		if(Mathf.Abs( Input.GetAxis("Horizontal") )> 0)
		{
			_animator.SetBool("IsMoving", true);
		}
		else _animator.SetBool("IsMoving", false);
	}
}
