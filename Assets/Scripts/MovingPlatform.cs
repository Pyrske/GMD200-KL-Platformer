using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Transform[] movePoints;

    private int _pointIndex = 0;
    private Transform _currentPoint;

    private SpriteRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _currentPoint = movePoints[_pointIndex];
        _renderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, _currentPoint.position, moveSpeed * Time.fixedDeltaTime);
        if (Vector2.SqrMagnitude(transform.position - _currentPoint.position) < 0.01f)
        {
            NextPoint();
        }
    }
    void NextPoint()
    {
        _pointIndex++;
        _pointIndex %= movePoints.Length;
        _currentPoint = movePoints[_pointIndex];
        _renderer.flipX = transform.position.x > _currentPoint.position.x;
    }
}
