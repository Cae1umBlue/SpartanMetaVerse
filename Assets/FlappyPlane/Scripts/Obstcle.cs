using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyPlane
    {
    public class Obstcle : MonoBehaviour
    {
        public float highPosY = 1f; //장애물의 Y축 상한선
        public float lowPosY = -1f; //장애물의 y축 하한선

        public float holeSizeMin = 1f; // 구멍의 최소 사이즈
        public float holeSizeMax = 3f; // 구멍의 최대 사이즈

        public Transform topObject; // 장애물의 상단 오브젝트
        public Transform bottomObject; // 장애물의 하단 오브젝트

        public float widthPadding = 4f; // 장애물 간의 X축 간격 (너비 패딩)

        MiniGameManager gameManager;

        public void Start()
        {
            gameManager = MiniGameManager.Instance;
        }

        public Vector3 SetRandomPlace(Vector3 LastPosition, int obstaclCount)
        {
            float holeSize = Random.Range(holeSizeMin, holeSizeMax); // 구멍 크기는 랜덤
            float halfHoleSize = holeSize; // 구멍 크기를 반으로 나누어 상단과 하단 객체의 Y위치 설정

            topObject.localPosition = new Vector3(0, halfHoleSize);
            bottomObject.localPosition = new Vector3(0, -halfHoleSize);

            Vector3 placePosition = LastPosition + new Vector3(widthPadding, 0);
            placePosition.y = Random.Range(lowPosY, highPosY);

            transform.position = placePosition;

            return placePosition;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Player player = collision.GetComponent<Player>();
            if (player != null) gameManager.AddScore(1);
        }
    }
}