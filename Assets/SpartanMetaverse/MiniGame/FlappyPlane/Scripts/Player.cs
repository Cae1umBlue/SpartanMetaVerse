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
        float deathCooldown = 0f; // 충돌 후 사망 시간

        bool isFlap = false; // 점프 유무

        public bool godMode = false; // 일종의 관리자 모드

        GameManager gameManager;

        void Start()
        {
            gameManager = GameManager.Instance;

            animator = GetComponentInChildren<Animator>(); //inchildren : 하위(자식)오브젝트 검색 가능
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
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //스페이스바 누를 때마다 true 반환
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
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //스페이스바 누를 때마다 true 반환
                {
                    isFlap = true;
                }
            }
        }

        private void FixedUpdate()
        {
            if (isDead) return;

            Vector3 velocity = _rigidbody.velocity; // rigidbody의 가속도 //vector3 = 구조체
            velocity.x = fowardSpeed;

            if (isFlap)
            {
                velocity.y += flapForce;
                isFlap = false;
            }

            _rigidbody.velocity = velocity;

            float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90); //  각도 조절
            transform.rotation = Quaternion.Euler(0, 0, angle); // 회전 (오일러함수)
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
