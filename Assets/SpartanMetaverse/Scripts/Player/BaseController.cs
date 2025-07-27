using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 캐릭터의 기본 움직임, 회전
public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer playerRenderer; //좌우반전 렌더러

    protected Vector2 movementDirection = Vector2.zero; // 현재 이동방향
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero; // 현재 바라보는 방향
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
    protected virtual void FixedUpdate() // rigidbody 오브젝트 조정 시 주로 사용
    {
        Movement(MovementDirection);
    }

    private void Movement(Vector2 direction)
    {
        direction = direction * 5; // 이동속도

        _rigidbody.velocity = direction; // 실제 물리 이동
    }

    private void Rotate(Vector2 direction)
    {
        // 좌우 스프라이트 변경을 위한 기준 각도 계산
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        playerRenderer.flipX = isLeft;
    }
}
