using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer playerRenderer;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        Rotate(LookDirection);
    }
    protected virtual void FixedUpdate()
    {
        Movement(LookDirection);
    }

    private void Movement(Vector2 direction)
    {
        direction = direction * 5;

        _rigidbody.velocity = direction;
    }

    private void Rotate(Vector2 direction)
    {
        // 회전을 구현하기 위해 역탄젠트 * 각도법 변환 사용
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        playerRenderer.flipX = isLeft;
    }
}
