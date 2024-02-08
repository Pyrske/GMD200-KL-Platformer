using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jump = 800f;

    private Rigidbody2D _rb;

    private float _moveInput;
    private bool _jumpInput;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveInput = Input.GetAxis("Horizontal") * _speed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpInput = true;
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_moveInput, _rb.velocity.y);
        if (_shouldJump)
        {
            _rb.AddForce(Vector2.up * _jump);
            _jumpInput = false;
        }
    }
}
