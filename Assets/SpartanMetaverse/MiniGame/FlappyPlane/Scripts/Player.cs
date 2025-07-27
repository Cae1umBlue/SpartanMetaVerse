using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGames.Flappy
{
    public class Player : MonoBehaviour
    {
        Animator animator;
        Rigidbody2D _rigidbody;

        public float flapForce = 6f;
        public float fowardSpeed = 3f;
        public bool isDead = false;
        float deathCooldown = 0f; // �浹 �� ��� �ð�

        bool isFlap = false; // ���� ����

        public bool godMode = false; // ������ ������ ���

        GameManager gameManager;

        void Start()
        {
            gameManager = GameManager.Instance;

            animator = GetComponentInChildren<Animator>(); //inchildren : ����(�ڽ�)������Ʈ �˻� ����
            _rigidbody = GetComponent<Rigidbody2D>();

            if (animator == null)
            {
                Debug.LogError("Not Founded Animator");
            }
            if (_rigidbody == null)
            {
                Debug.LogError("Not Founded RigidBody");
            }
        }

        void Update()
        {
            if (isDead)
            {
                if (deathCooldown <= 0f)
                {
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //�����̽��� ���� ������ true ��ȯ
                    {
                        gameManager.RestartGame();
                    }
                }
                else
                {
                    deathCooldown -= Time.deltaTime;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //�����̽��� ���� ������ true ��ȯ
                {
                    isFlap = true;
                }
            }
        }

        private void FixedUpdate()
        {
            if (isDead) return;

            Vector3 velocity = _rigidbody.velocity; // rigidbody�� ���ӵ� //vector3 = ����ü
            velocity.x = fowardSpeed;

            if (isFlap)
            {
                velocity.y += flapForce;
                isFlap = false;
            }

            _rigidbody.velocity = velocity;

            float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90); //  ���� ����
            transform.rotation = Quaternion.Euler(0, 0, angle); // ȸ�� (���Ϸ��Լ�)
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (godMode) return;

            if (isDead) return;

            isDead = true;
            deathCooldown = 1f;

            animator.SetInteger("IsDie", 1);
            gameManager.GameOver();
        }
    }
}
