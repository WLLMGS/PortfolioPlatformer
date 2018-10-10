using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerAnimationBehavior : MonoBehaviour
{

    private Animator _animator;
    
    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
       
#if DEBUG
        Assert.IsNotNull(_animator, "DEPENDENCY ERROR: no animator found in PlayerAnimationBehavior Script");
       #endif
    }

    // Update is called once per frame
    void Update()
    {
		CheckIfMoving();
        CheckJump();
        CheckIfAttacking();
    }

	void CheckIfMoving()
	{
		if(Mathf.Abs( Input.GetAxis("Horizontal") )> 0)
		{
			_animator.SetBool("IsMoving", true);
		}
		else _animator.SetBool("IsMoving", false);
	}
    void CheckJump()
    {
        if(Input.GetKeyDown(KeyCode.Space)) _animator.SetTrigger("Jump");
    }

    void CheckIfAttacking()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("Attack");
        }
    }
}
