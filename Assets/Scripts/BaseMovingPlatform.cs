using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovingPlatform : MonoBehaviour
{
    protected SpriteRenderer _renderer;

    protected virtual void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    protected void SetDirection(bool movingRight)
    {
        _renderer.flipX = !movingRight;
    }
}
