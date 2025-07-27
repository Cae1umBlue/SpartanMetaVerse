using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private Camera camera; // 메인카메라 참조(마우스 위치 월드좌표화)

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    // HandleAction 대신 Unity Input Actionm 사용
    void OnMove(InputValue inputValue) // WASD 이동
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }

    void OnLook(InputValue inputValue) // 마우스 위치에 따라 좌우 반전
    {
        Vector2 mousePosition = inputValue.Get<Vector2>();
        Vector2 worldPos = camera.WorldToScreenPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if(lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }
}
