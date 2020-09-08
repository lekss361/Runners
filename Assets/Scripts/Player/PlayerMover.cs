using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundChecker))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Animator _animator;
    [SerializeField] private Timer _timer;
    [SerializeField] private Classes _classes;

    private Rigidbody2D _rigidbody;
    private GroundChecker _groundChecker;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponent<GroundChecker>();

        ResetPlayer();
    }

    private void Update()
    {
        _rigidbody.transform.position = transform.position + new Vector3(_moveSpeed*Time.deltaTime,0,0);
        _animator.SetBool("Ground", true);

        if (Input.GetKeyDown(KeyCode.Space))
        {            
            if (_groundChecker.CheckGround())
            {
                _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
                _animator.SetBool("Ground", false);
            }          
        }
        if (Input.GetKeyDown(KeyCode.LeftControl)&&_timer.SPWR())
        {
            bool presskey = true;
            _timer.PressKey(presskey);
        }
    }

    public void ResetPlayer()
    {
        transform.position = _startPosition;   
    }
}
