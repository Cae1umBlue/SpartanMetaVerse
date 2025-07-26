using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyPlane
    {
    public class Obstcle : MonoBehaviour
    {
        public float highPosY = 1f; //��ֹ��� Y�� ���Ѽ�
        public float lowPosY = -1f; //��ֹ��� y�� ���Ѽ�

        public float holeSizeMin = 1f; // ������ �ּ� ������
        public float holeSizeMax = 3f; // ������ �ִ� ������

        public Transform topObject; // ��ֹ��� ��� ������Ʈ
        public Transform bottomObject; // ��ֹ��� �ϴ� ������Ʈ

        public float widthPadding = 4f; // ��ֹ� ���� X�� ���� (�ʺ� �е�)

        MiniGameManager gameManager;

        public void Start()
        {
            gameManager = MiniGameManager.Instance;
        }

        public Vector3 SetRandomPlace(Vector3 LastPosition, int obstaclCount)
        {
            float holeSize = Random.Range(holeSizeMin, holeSizeMax); // ���� ũ��� ����
            float halfHoleSize = holeSize; // ���� ũ�⸦ ������ ������ ��ܰ� �ϴ� ��ü�� Y��ġ ����

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