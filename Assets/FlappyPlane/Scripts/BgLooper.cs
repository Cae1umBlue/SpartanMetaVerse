using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGames.Flappy
{
    public class BgLooper : MonoBehaviour
    {
        public int numBgCount = 5;
        public int obstacleCount = 0;
        public Vector3 obstacleLastPosition = Vector3.zero;

        void Start() // 모든 장애물을 찾아와서 랜덤배치
        {
            Obstcle[] obstacles = GameObject.FindObjectsOfType<Obstcle>(); // obstacle 이 달려 있는 오브젝트 전부 가져옴
            obstacleLastPosition = obstacles[0].transform.position; // 첫번째 장애물의 위치를 저장
            obstacleCount = obstacles.Length; // 장애물의 개수를 계산하여 저장

            for (int i = 0; i < obstacleCount; i++) // 장애물의 개수만큼 반복하여 각 장애물의 위치를 랜덤하게 설정
            {
                obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount); // 각 장애물의 위치를 이전 장애물 위치를 기반으로 설정
            }
        }

        private void OnTriggerEnter2D(Collider2D collision) // 충돌을 감지해서 랜덤으로 반영되게 하기
        {
            Debug.Log("Triggered " + collision.name);

            if (collision.CompareTag("BackGround"))
            {
                float widthofBgObject = ((BoxCollider2D)collision).size.x;
                Vector3 pos = collision.transform.position;

                pos.x += widthofBgObject * numBgCount;
                collision.transform.position = pos;
                return;
            }

            Obstcle obstacle = collision.GetComponent<Obstcle>(); // 충돌한 객체가 obstacle인지 확인
            if (obstacle)
            {
                obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount); // 장애물 충돌시 랜덤 위치로 재배치
            }
        }
    }
}