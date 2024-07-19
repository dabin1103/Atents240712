using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /// <summary>
    /// �̵� �ӵ�
    /// </summary>
    public float moveSpeed = 3.0f;

    /// <summary>
    /// ���� �׷����� �ѹ� �պ��ϴµ� �ɸ��� �ð� ������(Ŀ������ �պ� �ӵ��� ��������)
    /// </summary>
    public float frequency = 2.0f;

    /// <summary>
    /// ���� �׷����� ������� ������Ű�� ��(��, �Ʒ� �����̴� ����)
    /// </summary>
    public float amplitude = 3.0f;

    /// <summary>
    /// �ð� ������ ����
    /// </summary>
    float elapsedTime = 0.0f;

    /// <summary>
    /// ���� ��ġ �����(������ ��ġ)
    /// </summary>
    float spawnY = 0.0f;

    // �ǽ�
    // 1. ��� ������ �������� �����δ�.
    // 2. ���Ʒ��� ����ġ���� �����δ�.

    private void Start()
    {
        // Mathf : ����Ƽ ���п� Ŭ����

        spawnY = transform.position.y;      // ���� ��ġ ����ϱ�
    }

    private void Update()
    {
        MoveUpdate(Time.deltaTime);         // �̵� ������Ʈó��
    }

    /// <summary>
    /// �̵� ó���� �ϴ� �Լ�
    /// </summary>
    /// <param name="deltaTime"></param>
    void MoveUpdate(float deltaTime)
    {
        elapsedTime += deltaTime * frequency;    // frequency��ŭ ������ �ð��� ����

        // �� ��ġ ����
        transform.position = new Vector3(
            transform.position.x - deltaTime * moveSpeed,   // ���� x��ġ���� ���� ����
            spawnY + Mathf.Sin(elapsedTime) * amplitude,    // ������ġ���� sin*amplitude �����ŭ ����
            0.0f);     
    }
}
