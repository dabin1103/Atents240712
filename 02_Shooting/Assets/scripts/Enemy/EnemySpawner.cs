using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // �ǽ�
    // 1. ���� �ð� �������� ���� �����Ѵ�.
    // 2. �����Ǵ� ������ ȭ�� ������ ��

    public float frequency = 3.0f;

    public float amplitude = 4.0f;

    float elapsedTime = 0.0f;

    float spawnY = 0.0f;

    private void Start()
    {
        spawnY = transform.position.y;
    }

    private void Update()
    {
        MoveUpdate(Time.deltaTime);
    }

    void MoveUpdate(float deltaTime)
    {
        elapsedTime += deltaTime * frequency;
    }
}
