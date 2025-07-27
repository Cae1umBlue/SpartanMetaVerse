using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private Camera camera; // ����ī�޶� ����(���콺 ��ġ ������ǥȭ)

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    // HandleAction ��� Unity Input Actionm ���
    void OnMove(InputValue inputValue) // WASD �̵�
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }

    void OnLook(InputValue inputValue) // ���콺 ��ġ�� ���� �¿� ����
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
