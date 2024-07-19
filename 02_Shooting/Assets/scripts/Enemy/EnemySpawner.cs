using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // 실습
    // 1. 일정 시간 간격으로 적을 생성한다.
    // 2. 생성되는 범위는 화면 오른쪽 밖

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
