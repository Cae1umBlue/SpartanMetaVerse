using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    private void Movement(Vector2 direction)
    {
        direction = direction * 5;
    }
}
