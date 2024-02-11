using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovement _playerMovement;

    private bool _facingRight = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_facingRight && _rb.velocity.x < -0.1)
        {
            Flip();
        } else if (!_facingRight && _rb.velocity.x > 0.1)
        {
            Flip();
        }

        _animator.SetFloat("MoveSpeedX", Mathf.Abs(_rb.velocity.x) / _playerMovement.XSpeed);
        _animator.SetBool("Grounded", _playerMovement.IsGrounded);
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
