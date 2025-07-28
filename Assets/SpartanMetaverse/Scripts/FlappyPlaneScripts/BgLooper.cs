using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class BgLooper : MonoBehaviour
    {
        public int numBgCount = 5;
        public int obstacleCount = 0;
        public Vector3 obstacleLastPosition = Vector3.zero;

        void Start() // ��� ��ֹ��� ã�ƿͼ� ������ġ
        {
            Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>(); // obstacle �� �޷� �ִ� ������Ʈ ���� ������
            obstacleLastPosition = obstacles[0].transform.position; // ù��° ��ֹ��� ��ġ�� ����
            obstacleCount = obstacles.Length; // ��ֹ��� ������ ����Ͽ� ����

            for (int i = 0; i < obstacleCount; i++) // ��ֹ��� ������ŭ �ݺ��Ͽ� �� ��ֹ��� ��ġ�� �����ϰ� ����
            {
                obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount); // �� ��ֹ��� ��ġ�� ���� ��ֹ� ��ġ�� ������� ����
            }
        }

        private void OnTriggerEnter2D(Collider2D collision) // �浹�� �����ؼ� �������� �ݿ��ǰ� �ϱ�
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

            Obstacle obstacle = collision.GetComponent<Obstacle>(); // �浹�� ��ü�� obstacle���� Ȯ��
            if (obstacle)
            {
                obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount); // ��ֹ� �浹�� ���� ��ġ�� ���ġ
            }
        }
    }