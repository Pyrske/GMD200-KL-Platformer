using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    public float XSpeed => _speed;
    [SerializeField] private float _jump = 800f;
    [SerializeField] private float _groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D _rb;

    private float _moveInput;
    private bool _jumpInput;
    private bool isGrounded;
    public bool IsGrounded => isGrounded;

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
        Collider2D collider = Physics2D.OverlapCircle(transform.position, _groundCheckRadius, groundLayer);
        isGrounded = collider != null;
        _rb.velocity = new Vector2(_moveInput, _rb.velocity.y);
        if (_jumpInput)
        {
            if (isGrounded)
            {
                _rb.AddForce(Vector2.up * _jump);
            }
            _jumpInput = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position, _groundCheckRadius);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(other.transform, true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(null, true);
        }
    }
}
